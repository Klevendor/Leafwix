using LeafwixServerBLL.Models;
using LeafwixServerDAL.Constants.Errors.Base;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Entities.App.HelperTypes;
using OneOf;

namespace LeafwixServerBLL.Services.Interfaces
{
    public interface INotificationSettingsService
    {
        Task<OneOf<NotificationSettingsResponse, Error>> GetByUserIdAsync(Guid userId);
        Task AddAsync(Guid userId);
        Task<OneOf<Unit, Error>> UpdateAsync(NotificationSettingsRequest settings);
    }
}
