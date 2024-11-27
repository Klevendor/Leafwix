using LeafwixServerDAL.Entities.App;

namespace LeafwixServerBLL.Services.Interfaces
{
    public interface INotificationSettingsService
    {
        Task<IEnumerable<NotificationSettings>> GetAllAsync();
        Task<NotificationSettings> GetByIdAsync(Guid id);
        Task AddAsync(NotificationSettings settings);
        Task UpdateAsync(NotificationSettings settings);
        Task DeleteAsync(Guid id);
    }
}
