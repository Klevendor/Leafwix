using LeafwixServerDAL.Context.Implementation;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeafwixServerDAL.Repositories.Implementation
{
    public class PlantRepository : GenericRepository<Plant>, IPlantRepository
    {
        public PlantRepository(ApplicationDbContext сontext) : base(сontext) { }

        public async Task<List<Plant>> GetAllPlantsAsync(Guid userId)
        {
            return await _context.Plants.Where(p => p.UserId == userId).Include(p => p.PlantSpecies).ToListAsync();
        }

        public async Task<Plant?> GetPlantAsync(Guid userId, Guid plantId)
        {
            return await _context.Plants.Where(p => p.UserId == userId && p.Id == plantId).Include(p=>p.PlantSpecies).FirstOrDefaultAsync();
        }
    }
}
