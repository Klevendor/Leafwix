using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Enums;

namespace LeafwixServerDAL.Repositories.Interfaces
{
    public interface IPlantCareHistoryRepository : IGenericRepository<PlantCareHistory>
    {
        Task<List<PlantCareHistory>> GetPlantCareHistoryAsync(Guid userId, CareType careType);
    }
}
