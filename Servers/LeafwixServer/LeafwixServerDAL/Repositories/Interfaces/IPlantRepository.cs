using LeafwixServerDAL.Entities.App;

namespace LeafwixServerDAL.Repositories.Interfaces
{
    public interface IPlantRepository : IGenericRepository<Plant>
    {
        Task<List<Plant>> GetAllPlantsAsync(Guid userId);
        Task<Plant?> GetPlantAsync(Guid userId, Guid plantId);
    }
}
