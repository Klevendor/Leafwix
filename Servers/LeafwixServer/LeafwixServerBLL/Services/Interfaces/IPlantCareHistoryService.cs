using LeafwixServerBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafwixServerBLL.Services.Interfaces
{
    public interface IPlantCareHistoryService
    {
        Task<List<PlantCareHistoryResponse>> GetPlantCareHistoryAsync(Guid userId, string careType);
        Task AddPlantCareHistoryAsync(PlantCareHistoryCreateRequest dto);

    }
}
