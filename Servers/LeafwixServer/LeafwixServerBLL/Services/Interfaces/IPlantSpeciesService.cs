using LeafwixServerDAL.Entities.App;

namespace LeafwixServerBLL.Services.Interfaces
{
    public interface IPlantSpeciesService
    {
        Task<IEnumerable<PlantSpecies>> GetAllAsync();
        Task<PlantSpecies> GetByIdAsync(Guid id);
        Task AddAsync(PlantSpecies species);
        Task UpdateAsync(PlantSpecies species);
        Task DeleteAsync(Guid id);
    }
}
