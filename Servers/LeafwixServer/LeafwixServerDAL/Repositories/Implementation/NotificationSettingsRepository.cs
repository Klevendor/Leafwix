using LeafwixServerDAL.Context.Implementation;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Repositories.Interfaces;

namespace LeafwixServerDAL.Repositories.Implementation
{
    public class NotificationSettingsRepository : GenericRepository<NotificationSettings>, INotificationSettingsRepository
    {
        public NotificationSettingsRepository(ApplicationDbContext context) : base(context) { }


    }
}
