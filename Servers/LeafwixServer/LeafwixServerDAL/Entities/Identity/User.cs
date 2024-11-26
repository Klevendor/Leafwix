using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Entities.Security;
using Microsoft.AspNetCore.Identity;

namespace LeafwixServerDAL.Entities.Identity
{
    public class User: IdentityUser<Guid>
    {
        public List<RefreshToken> RefreshTokens { get; set; }        // Навігаційна властивість до налаштувань сповіщень
        
        public NotificationSettings NotificationSettings { get; set; }

        public List<Plant> Plants { get; set; }
    }
}
