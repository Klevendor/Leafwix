using LeafwixServerBLL.Services.Interfaces;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Repositories.Interfaces;

namespace LeafwixServerBLL.Services.Implementation
{
    public class PlantDiseasesService : IPlantDiseasesService
    {
        private readonly IPlantDiseasesRepository _repository;

        public PlantDiseasesService(IPlantDiseasesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PlantDiseases>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<PlantDiseases> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task AddAsync(PlantDiseases disease) => await _repository.AddAsync(disease);

        public async Task UpdateAsync(PlantDiseases disease) => await _repository.UpdateAsync(disease);

        public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
    }
}
