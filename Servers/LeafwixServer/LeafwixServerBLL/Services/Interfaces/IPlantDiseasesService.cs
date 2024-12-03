using LeafwixServerBLL.Models;
using LeafwixServerDAL.Entities.App;

namespace LeafwixServerBLL.Services.Interfaces
{
    public interface IPlantDiseasesService
    {
        Task<List<PlantDiseaseResponse>> GetAllAsync();
        Task<PlantDiseaseResponse> GetByIdAsync(Guid id);
        Task AddAsync(PlantDiseaseCreateRequest disease);
        Task UpdateAsync(PlantDiseaseUpdateRequest disease);
        Task DeleteAsync(Guid id);
    }
}
