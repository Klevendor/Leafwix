using LeafwixServerDAL.Context.Implementation;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Repositories.Interfaces;

namespace LeafwixServerDAL.Repositories.Implementation
{
    public class PlantSpeciesRepository : GenericRepository<PlantSpecies>, IPlantSpeciesRepository
    {
        public PlantSpeciesRepository(ApplicationDbContext context) : base(context) { }

    }
}
