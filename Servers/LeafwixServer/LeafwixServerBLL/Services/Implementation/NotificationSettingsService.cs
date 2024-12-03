using LeafwixServerBLL.Models;
using LeafwixServerBLL.Services.Interfaces;
using LeafwixServerDAL.Context.Interfaces;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Repositories.Interfaces;
using LeafwixServerDAL.Constants.Errors.Base;
using LeafwixServerDAL.Constants.Errors.Types;
using OneOf;
using LeafwixServerDAL.Entities.Identity;
using LeafwixServerDAL.Entities.App.HelperTypes;

namespace LeafwixServerBLL.Services.Implementation
{
    public class NotificationSettingsService : INotificationSettingsService
    {
        private readonly INotificationSettingsRepository _repository;
        private readonly IAuthService _authService;

        public NotificationSettingsService(INotificationSettingsRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<OneOf<NotificationSettingsResponse, Error>> GetByUserIdAsync(Guid userId) 
        {
            // Знаходимо користувача за userId
            var user = await _authService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return Errors.Authorization.UserNotFound;
            }
            // Отримуємо NotificationSettings для цього користувача
            var settings = await _repository.GetNotificationSettingsByUserIdAsync(userId);
            if (settings == null)
            {
                return Errors.NotificationSettings.NotificationSettingsNotFound;
            }
            return new NotificationSettingsResponse
            (
                settings.PreferredNotificationTime,
                settings.EnableNotifications,
                settings.TimeZone
            );
        }

        // Додавання базових налаштувань для нового користувача
        public async Task AddAsync(Guid userId)
        {
            var defaultSettings = new NotificationSettings
            {
                UserId = userId,
                PreferredNotificationTime = new TimeSpan(9, 0, 0), // Час сповіщення
                EnableNotifications = true,
                TimeZone = "Europe/Kyiv"
            };

            await _repository.AddAsync(defaultSettings);
        }

        public async Task<OneOf<Unit, Error>> UpdateAsync(NotificationSettingsRequest settings)
        {

            var notificationSettings = await _repository.GetNotificationSettingsByUserIdAsync(settings.userId);

            if (notificationSettings == null)
            {
                return Errors.NotificationSettings.NotificationSettingsNotFound;
            }

            notificationSettings.PreferredNotificationTime = settings.PreferredNotificationTime;
            notificationSettings.EnableNotifications = settings.EnableNotifications;
            notificationSettings.TimeZone = settings.TimeZone;

            await _repository.UpdateAsync(notificationSettings);

            return new Unit();
        }

    }
}
