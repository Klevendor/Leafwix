using LeafwixServerBLL.Services.Interfaces;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Repositories.Interfaces;

namespace LeafwixServerBLL.Services.Implementation
{
    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _repository;

        public PlantService(IPlantRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Plant>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Plant> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task AddAsync(Plant plant) => await _repository.AddAsync(plant);

        public async Task UpdateAsync(Plant plant) => await _repository.UpdateAsync(plant);

        public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
    }
}
