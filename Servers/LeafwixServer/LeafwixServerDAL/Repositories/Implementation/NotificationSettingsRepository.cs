using LeafwixServerDAL.Context.Implementation;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeafwixServerDAL.Repositories.Implementation
{
    public class NotificationSettingsRepository : GenericRepository<NotificationSettings>, INotificationSettingsRepository
    {
        public NotificationSettingsRepository(ApplicationDbContext context) : base(context) { }

        public async Task<NotificationSettings?> GetNotificationSettingsByUserIdAsync(Guid userId)
        {
            return await _context.NotificationSettings.FirstOrDefaultAsync(ns => ns.UserId == userId);
        }
    }
}
