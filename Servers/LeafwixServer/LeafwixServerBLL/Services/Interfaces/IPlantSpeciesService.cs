using LeafwixServerBLL.Models;
using LeafwixServerDAL.Entities.App;

namespace LeafwixServerBLL.Services.Interfaces
{
    public interface IPlantSpeciesService
    {
        Task<IEnumerable<PlantSpeciesResponse>> GetAllAsync();
        Task<PlantSpeciesResponse> GetByIdAsync(Guid id);
        Task AddAsync(PlantSpeciesCreateRequest createDto);
        Task UpdateAsync(PlantSpeciesUpdateRequest updateDto);
        Task DeleteAsync(Guid id);
    }
}
