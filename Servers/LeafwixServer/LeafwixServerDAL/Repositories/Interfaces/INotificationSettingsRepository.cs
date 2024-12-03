using LeafwixServerDAL.Entities.App;

namespace LeafwixServerDAL.Repositories.Interfaces
{
    public interface INotificationSettingsRepository : IGenericRepository<NotificationSettings>
    {
        Task<NotificationSettings?> GetNotificationSettingsByUserIdAsync(Guid userId);
    }
}
