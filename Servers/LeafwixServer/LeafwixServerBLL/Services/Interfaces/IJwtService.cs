using LeafwixServerDAL.Entities.Identity;
using LeafwixServerDAL.Entities.Security;

namespace LeafwixServerBLL.Services.Interfaces
{
    public interface IJwtService
    {
        public Task<string> GenerateJwtTokenAsync(User user);
        public Task<(string Token, DateTime Expires, DateTime Created)> GenerateJwtTokenWithDates(User user);
        public Guid ValidateJwtToken(string token);
        public RefreshToken GenerateRefreshToken();
    }
}
