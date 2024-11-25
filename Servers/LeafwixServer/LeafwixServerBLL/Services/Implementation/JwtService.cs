using LeafwixServerBLL.Services.Interfaces;
using LeafwixServerDAL.Constants.Settings;
using LeafwixServerDAL.Context.Interfaces;
using LeafwixServerDAL.Entities.Identity;
using LeafwixServerDAL.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LeafwixServerBLL.Services.Implementation
{
    public class JwtService : IJwtService
    {
        private readonly IApplicationDbContext _applicationDbContext;

        private readonly UserManager<User> _userManager;

        private readonly JwtSettings _appSettings;

        public JwtService(IApplicationDbContext context, IOptions<JwtSettings> appSettings, UserManager<User> userManager)
        {
            _applicationDbContext = context;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        public async Task<string> GenerateJwtTokenAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("guid", user.Id.ToString())
            };
            claims.AddRange(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _appSettings.Issuer,
                audience: _appSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_appSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        public async Task<(string Token, DateTime Expires, DateTime Created)> GenerateJwtTokenWithDates(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("guid", user.Id.ToString())
            };
            claims.AddRange(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var expiredDay = DateTime.UtcNow.AddMinutes(_appSettings.DurationInMinutes);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _appSettings.Issuer,
                audience: _appSettings.Audience,
                claims: claims,
                expires: expiredDay,
                signingCredentials: signingCredentials);

            return (new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), expiredDay, DateTime.UtcNow);
        }

        public Guid ValidateJwtToken(string token)
        {
            if (token == null)
                return Guid.Empty;

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret)),
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = _appSettings.Issuer,
                    ValidAudience = _appSettings.Audience
                };

                tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "guid").Value);

                return userId;
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = GenerateUniqueToken(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
            };

            return refreshToken;
        }

        private string GenerateUniqueToken()
        {
            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

            var tokenIsUnique = !_applicationDbContext.Users.Any(u => u.RefreshTokens.Any(t => t.Token == token));
            if (!tokenIsUnique)
                return GenerateUniqueToken();

            return token;
        }
    }
}
