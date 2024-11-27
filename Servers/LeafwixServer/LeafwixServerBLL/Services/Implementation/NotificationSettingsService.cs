using LeafwixServerBLL.Services.Interfaces;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Repositories.Interfaces;

namespace LeafwixServerBLL.Services.Implementation
{
    public class NotificationSettingsService : INotificationSettingsService
    {
        private readonly INotificationSettingsRepository _repository;

        public NotificationSettingsService(INotificationSettingsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<NotificationSettings>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<NotificationSettings> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task AddAsync(NotificationSettings settings) => await _repository.AddAsync(settings);

        public async Task UpdateAsync(NotificationSettings settings) => await _repository.UpdateAsync(settings);

        public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
    }
}
