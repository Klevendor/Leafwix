using LeafwixServerDAL.Context.Implementation;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Repositories.Interfaces;

namespace LeafwixServerDAL.Repositories.Implementation
{
    public class PlantDiseasesRepository : GenericRepository<PlantDiseases>, IPlantDiseasesRepository
    {
        public PlantDiseasesRepository(ApplicationDbContext context) : base(context) { }

    }
}
