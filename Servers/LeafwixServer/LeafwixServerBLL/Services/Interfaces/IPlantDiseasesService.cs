using LeafwixServerDAL.Entities.App;

namespace LeafwixServerBLL.Services.Interfaces
{
    public interface IPlantDiseasesService
    {
        Task<IEnumerable<PlantDiseases>> GetAllAsync();
        Task<PlantDiseases> GetByIdAsync(Guid id);
        Task AddAsync(PlantDiseases disease);
        Task UpdateAsync(PlantDiseases disease);
        Task DeleteAsync(Guid id);
    }
}
