using LeafwixServerDAL.Entities.App;
using Microsoft.AspNetCore.Identity;

namespace LeafwixServerDAL.Entities.Identity
{
    public class User: IdentityUser<Guid>
    {


        // Навігаційна властивість до налаштувань сповіщень
        public NotificationSettings NotificationSettings { get; set; }

        public List<Plant> Plants { get; set; }
    }
}
