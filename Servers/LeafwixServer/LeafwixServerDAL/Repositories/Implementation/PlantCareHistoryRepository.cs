using LeafwixServerDAL.Context.Implementation;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Enums;
using LeafwixServerDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeafwixServerDAL.Repositories.Implementation
{
    public class PlantCareHistoryRepository : GenericRepository<PlantCareHistory>, IPlantCareHistoryRepository
    {
        public PlantCareHistoryRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<PlantCareHistory>> GetPlantCareHistoryAsync(Guid userId, CareType careType)
        {
            return await _context.PlantCareHistories
                        .Where(pch => pch.Plant.UserId == userId && pch.CareType == careType)
                        .Include(pch => pch.Plant)
                        .ToListAsync();
        }
    }
}
