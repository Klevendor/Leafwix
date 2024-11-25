using LeafwixServerBLL.Models;
using LeafwixServerDAL.Constants.Errors.Base;
using LeafwixServerDAL.Entities.App.HelperTypes;
using LeafwixServerDAL.Entities.Identity;
using OneOf;

namespace LeafwixServerBLL.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<OneOf<AuthenticationResponse, Error>> RegisterAsync(UserRegisterInformation userRegisterInfo);
        public Task<OneOf<AuthenticationResponse, Error>> LoginAsync(UserLoginInformation userLoginInfo);
        public Task<OneOf<RefreshDataResponse, Error>> RefreshTokensAsync(string token, string ipAddress);
        public Task<OneOf<Unit,Error>> RevokeRefreshTokenAsync(RevokeRefreshTokenInformation revokeRefreshTokenInfo);
        public Task<OneOf<Unit,Error>> ForgotPasswordAsync(ForgotPasswordInformation forgotPasswordInfo);
        public Task<OneOf<Unit,Error>> ResetPasswordAsync(ResetPasswordInformation resetPasswordInfo);

        public Task<User?> GetUserByIdAsync(Guid id);
        public Task<User?> GetUserByUserNameAsync(string username);
        public Task<IList<string>> GetUserRolesAsync(User? user);
    }
}
