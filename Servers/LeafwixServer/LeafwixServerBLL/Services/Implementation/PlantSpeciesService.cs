using LeafwixServerBLL.Services.Interfaces;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Repositories.Interfaces;

namespace LeafwixServerBLL.Services.Implementation
{
    public class PlantSpeciesService : IPlantSpeciesService
    {
        private readonly IPlantSpeciesRepository _repository;

        public PlantSpeciesService(IPlantSpeciesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PlantSpecies>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<PlantSpecies> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task AddAsync(PlantSpecies species) => await _repository.AddAsync(species);

        public async Task UpdateAsync(PlantSpecies species) => await _repository.UpdateAsync(species);

        public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
    }
}
