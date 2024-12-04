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
            return await _context.Plants.Include(p => p.PlantSpecies)
            .ThenInclude(ps => ps.PlantImages).Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<Plant?> GetPlantAsync(Guid userId, Guid plantId)
        {
            return await _context.Plants.Include(p => p.PlantSpecies)
            .ThenInclude(ps => ps.PlantImages).FirstOrDefaultAsync(p => p.UserId == userId && p.Id == plantId);
        }
    }
}
