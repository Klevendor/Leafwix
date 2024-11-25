using LeafwixServerDAL.Entities.Security;
using Microsoft.AspNetCore.Identity;

namespace LeafwixServerDAL.Entities.Identity
{
    public class User: IdentityUser<Guid>
    {
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
