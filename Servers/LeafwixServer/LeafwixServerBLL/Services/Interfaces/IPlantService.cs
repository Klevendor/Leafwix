using LeafwixServerBLL.Models;
using OneOf;

namespace LeafwixServerBLL.Services.Interfaces
{
    public interface IPlantService
    {
        Task<List<PlantListResponse>> GetAllPlantsAsync(Guid userId);
        Task<PlantResponse?> GetPlantAsync(Guid userId, Guid plantId);
        Task AddPlantAsync(AddPlantRequest addPlantRequest);
        Task UpdatePlantAsync(UpdatePlantRequest updatePlantRequest);
        Task DeletePlantAsync(Guid userId, Guid plantId);
    }
}
