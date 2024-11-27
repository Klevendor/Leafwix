using LeafwixServerDAL.Context.Implementation;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Repositories.Interfaces;

namespace LeafwixServerDAL.Repositories.Implementation
{
    public class PlantRepository : GenericRepository<Plant>, IPlantRepository
    {
        public PlantRepository(ApplicationDbContext сontext) : base(сontext) { }

    }
}
