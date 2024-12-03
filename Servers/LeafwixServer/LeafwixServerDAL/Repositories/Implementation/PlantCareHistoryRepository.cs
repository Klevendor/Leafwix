using LeafwixServerDAL.Context.Implementation;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Repositories.Interfaces;

namespace LeafwixServerDAL.Repositories.Implementation
{
    public class PlantCareHistoryRepository : GenericRepository<PlantCareHistory>, IPlantCareHistoryRepository
    {
        public PlantCareHistoryRepository(ApplicationDbContext context) : base(context) { }
    }
}
