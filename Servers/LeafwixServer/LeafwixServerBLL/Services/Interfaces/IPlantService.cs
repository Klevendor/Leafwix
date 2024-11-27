using LeafwixServerDAL.Entities.App;

namespace LeafwixServerBLL.Services.Interfaces
{
    public interface IPlantService
    {
        Task<IEnumerable<Plant>> GetAllAsync();
        Task<Plant> GetByIdAsync(Guid id);
        Task AddAsync(Plant plant);
        Task UpdateAsync(Plant plant);
        Task DeleteAsync(Guid id);
    }
}
