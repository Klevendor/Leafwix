using LeafwixServerBLL.Services.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace LeafwixServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantDiseasesController : ControllerBase
    {

        private readonly IPlantDiseasesService _plantDiseasesService;

        public PlantDiseasesController(IPlantDiseasesService plantDiseasesService)
        {
            _plantDiseasesService = plantDiseasesService;
        }


    }
}
