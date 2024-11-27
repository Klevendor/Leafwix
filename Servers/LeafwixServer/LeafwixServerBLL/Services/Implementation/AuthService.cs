using LeafwixServerBLL.Models;
using LeafwixServerBLL.Services.Interfaces;
using LeafwixServerDAL.Constants.Errors.Base;
using LeafwixServerDAL.Constants.Errors.Types;
using LeafwixServerDAL.Context.Interfaces;
using LeafwixServerDAL.Entities.App.HelperTypes;
using LeafwixServerDAL.Entities.Identity;
using LeafwixServerDAL.Enums;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneOf;

namespace LeafwixServerBLL.Services.Implementation
{
    public class AuthService: IAuthService
    {
        private readonly IApplicationDbContext _aplicationDbContext;

        private readonly IJwtService _jwtService;

        private readonly IEmailService _emailService;

        private readonly IMapper _mapper;

        private readonly UserManager<User> _userManager;

        public AuthService(
            IApplicationDbContext aplicationDbContext,
            IJwtService jwtService,
            IEmailService emailService,
            IMapper mapper,
            UserManager<User> userManager
            )
        {
            _aplicationDbContext = aplicationDbContext;
            _jwtService = jwtService;
            _emailService = emailService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<OneOf<AuthenticationResponse, Error>> LoginAsync(UserLoginInformation userLoginInfo)
        {
            var user = await _userManager.FindByEmailAsync(userLoginInfo.Email);

            if (user == null)
            {
                return Errors.Authorization.InvalidEmailOrPassword;
            }

            user.RefreshTokens = await _aplicationDbContext.RefreshTokens.Where(p => p.OwnerId == user.Id).ToListAsync();


            if (await _userManager.IsLockedOutAsync(user))
            {
                return Errors.Authorization.BannedUser;
            }

            if (!await _userManager.CheckPasswordAsync(user, userLoginInfo.Password))
            {
                return Errors.Authorization.InvalidEmailOrPassword;
            }

            var authenticationInfo = new AuthenticationResponse();

            authenticationInfo.Id = user.Id;
            authenticationInfo.Email = user.Email;
            authenticationInfo.UserName = user.UserName;

            var tokenWithDates = await _jwtService.GenerateJwtTokenWithDates(user);
            authenticationInfo.Token = tokenWithDates.Token;

            var userRoles = await _userManager.GetRolesAsync(user);
            authenticationInfo.UserRoles = userRoles.ToList();

            if (user.RefreshTokens.Any(a => a.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.Where(a => a.IsActive == true).FirstOrDefault();
                authenticationInfo.RefreshToken = activeRefreshToken?.Token ?? "";
                authenticationInfo.RefreshTokenExpiration = activeRefreshToken?.Expires ?? new DateTime();
            }
            else
            {
                var refreshToken = _jwtService.GenerateRefreshToken();
                authenticationInfo.RefreshToken = refreshToken.Token;
                authenticationInfo.RefreshTokenExpiration = refreshToken.Expires;
                user.RefreshTokens.Add(refreshToken);
                _aplicationDbContext.Update(user);
            }

            await _aplicationDbContext.SaveChangesAsync();

            return authenticationInfo;
        }

        public async Task<OneOf<AuthenticationResponse, Error>> RegisterAsync(UserRegisterInformation userRegisterInfo)
        {
            var user = _mapper.Map<User>(userRegisterInfo);
            var resFindUser = await _userManager.FindByNameAsync(userRegisterInfo.UserName);
            if (resFindUser != null)
            {
                return Errors.Authorization.UsernameExists;
            }

            var resCreatingUser = await _userManager.CreateAsync(user, userRegisterInfo.Password);
            if (!resCreatingUser.Succeeded)
            {
                // TODO email alredy exist error
                return Errors.Authorization.RegistrationFailed;
            }

            var resAddRole = await _userManager.AddToRoleAsync(user, AppRoles.User.ToString());
            if (!resAddRole.Succeeded)
            {
                return Errors.Authorization.RegistrationFailed;
            }

            var registeredUser = await _userManager.FindByNameAsync(userRegisterInfo.UserName);
            if (registeredUser == null)
            {
                return Errors.Authorization.RegistrationFailed;
            }

            var resUserRoles = await _userManager.GetRolesAsync(registeredUser);

            await _aplicationDbContext.SaveChangesAsync();

            var result = _mapper.Map<AuthenticationResponse>(registeredUser);
            result.UserRoles = resUserRoles;
            return result;
        }

        public async Task<OneOf<RefreshDataResponse, Error>> RefreshTokensAsync(string token, string ipAddress)
        {
            var user = _aplicationDbContext.Users
                .Include(p => p.RefreshTokens)
                .SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
                return Errors.Authorization.UserNotFound;

            var refreshToken = user.RefreshTokens.SingleOrDefault(x => x.Token == token);

            if (refreshToken == null || !refreshToken.IsActive)
                return Errors.Authorization.TokenNotFound;

            refreshToken.Revoked = DateTime.UtcNow;

            var newRefreshToken = _jwtService.GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);

            RemoveOldRefreshTokens(user);

            var tokenWithDates = await _jwtService.GenerateJwtTokenWithDates(user);

            var jwtToken = tokenWithDates.Token;
            var roles = await _userManager.GetRolesAsync(user);

            await _aplicationDbContext.SaveChangesAsync();

            return new RefreshDataResponse(
                user.Id,
                user.Email,
                user.UserName,
                roles.ToList(),
                jwtToken,
                newRefreshToken.Token,
                newRefreshToken.Expires
            );
        }

        public async Task<OneOf<Unit, Error>> ForgotPasswordAsync(ForgotPasswordInformation forgotPasswordInfo)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordInfo.Email);
            if (user == null)
                return Errors.Authorization.InvalidEmail;

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            await _emailService.SendEmailAsync(forgotPasswordInfo.Email, "Reset your password",
               $"To reset your password, follow the link: <a href='http://localhost:5173/resetpassword/info?token={token}&email={forgotPasswordInfo.Email}'>Reset password</a>");

            return new Unit();
        }

        public async Task<OneOf<Unit, Error>> ResetPasswordAsync(ResetPasswordInformation resetPasswordInfo)
        {
            var token = resetPasswordInfo.Token.Replace(' ', '+');

            var user = await _userManager.FindByEmailAsync(resetPasswordInfo.Email);

            if (user == null)
                return Errors.Authorization.InvalidEmail;

            var result = await _userManager.ResetPasswordAsync(user, token, resetPasswordInfo.NewPassword);

            if (!result.Succeeded)
                return Errors.Authorization.InvalidTokenOrPassword;

            return new Unit();
        }

        public async Task<OneOf<Unit, Error>> RevokeRefreshTokenAsync(RevokeRefreshTokenInformation revokeRefreshTokenInfo)
        {
            var user = _aplicationDbContext.Users.Include(p => p.RefreshTokens).SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == revokeRefreshTokenInfo.Token));

            if (user == null)
                return Errors.Authorization.InvalidToken;

            var refreshToken = user.RefreshTokens.Single(x => x.Token == revokeRefreshTokenInfo.Token);

            refreshToken.Revoked = DateTime.UtcNow;

            _aplicationDbContext.Update(user);
            await _aplicationDbContext.SaveChangesAsync();

            return new Unit();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return user;
        }

        public async Task<User?> GetUserByUserNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user;
        }

        public async Task<IList<string>> GetUserRolesAsync(User? user)
        {
            if (user == null)
                return new List<string>();

            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }

        /* 
         
        Methods for help
         
        */

        private void RemoveOldRefreshTokens(User user)
        {
            user.RefreshTokens.RemoveAll(x =>
                !x.IsActive &&
                x.Created.AddDays(2) <= DateTime.UtcNow);

            //TODO fix REFRESH DOUBLE
            //user.RefreshTokens.RemoveAll(x =>
            //   !x.IsActive);
        }
    }
}
