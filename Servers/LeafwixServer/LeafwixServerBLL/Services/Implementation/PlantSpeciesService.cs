using LeafwixServerBLL.Models;
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

        public async Task<IEnumerable<PlantSpeciesResponse>> GetAllAsync()
        {
            var species = await _repository.GetAllAsync();

            return species.Select(ps => new PlantSpeciesResponse
            {
                Id = ps.Id,
                Name = ps.Name,
                Description = ps.Description,
                Watering = ps.Watering,
                Lighting = ps.Lighting,
                SoilType = ps.SoilType,
                Humidity = ps.Humidity,
                Temperature = ps.Temperature,
                InterestingFacts = ps.InterestingFacts,
            });
        }

        public async Task<PlantSpeciesResponse> GetByIdAsync(Guid id)
        {
            var ps = await _repository.GetByIdAsync(id);
            if (ps == null) return null;

            return new PlantSpeciesResponse
            {
                Id = ps.Id,
                Name = ps.Name,
                Description = ps.Description,
                Watering = ps.Watering,
                Lighting = ps.Lighting,
                SoilType = ps.SoilType,
                Humidity = ps.Humidity,
                Temperature = ps.Temperature,
                InterestingFacts = ps.InterestingFacts 
            };
        }

        public async Task AddAsync(PlantSpeciesCreateRequest createDto)
        {
            var plantSpecies = new PlantSpecies
            {
                Id = Guid.NewGuid(),
                Name = createDto.Name,
                Description = createDto.Description,
                Watering = createDto.Watering,
                Lighting = createDto.Lighting,
                SoilType = createDto.SoilType,
                Humidity = createDto.Humidity,
                Temperature = createDto.Temperature,
                InterestingFacts = createDto.InterestingFacts
            };

            await _repository.AddAsync(plantSpecies);
        }

        public async Task UpdateAsync(PlantSpeciesUpdateRequest updateDto)
        {
            var existing = await _repository.GetByIdAsync(updateDto.Id);
            if (existing == null) throw new KeyNotFoundException("Plant species not found");

            existing.Name = updateDto.Name;
            existing.Description = updateDto.Description;
            existing.Watering = updateDto.Watering;
            existing.Lighting = updateDto.Lighting;
            existing.SoilType = updateDto.SoilType;
            existing.Humidity = updateDto.Humidity;
            existing.Temperature = updateDto.Temperature;
            existing.InterestingFacts = updateDto.InterestingFacts;

            await _repository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(Guid id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) throw new KeyNotFoundException("Plant species not found");
            await _repository.DeleteAsync(existing); 
        }
    }
}
