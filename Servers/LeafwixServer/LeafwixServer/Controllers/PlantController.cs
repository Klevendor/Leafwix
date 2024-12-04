using LeafwixServerBLL.Services.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using LeafwixServer.Authorization.CustomAttributes;
using LeafwixServerBLL.Models;

namespace LeafwixServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ApiController
    {
        private readonly IPlantService _plantService;

        public PlantController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        //[Authorize("User,Administrator,Moderator")]
        [HttpGet("getAll/{userId}")]
        public async Task<IActionResult> GetAllPlants(Guid userId)
        {
            var plants = await _plantService.GetAllPlantsAsync(userId);
            return Ok(plants);
        }

        //[Authorize("User,Administrator,Moderator")]
        [HttpGet("getSingle")]
        public async Task<IActionResult> GetPlant(Guid userId, Guid plantId)
        {
            var plant = await _plantService.GetPlantAsync(userId, plantId);
            if (plant == null) return NotFound();

            return Ok(plant);
        }

        //[Authorize("User,Administrator,Moderator")]
        [HttpPost("add-plant")]
        public async Task<IActionResult> AddPlant([FromBody] AddPlantRequest addPlantRequest)
        {
            await _plantService.AddPlantAsync(addPlantRequest);
            return Ok();
        }

        //[Authorize("User,Administrator,Moderator")]
        [HttpPut("update-plant")]
        public async Task<IActionResult> UpdatePlant([FromBody] UpdatePlantRequest updatePlantRequest)
        {
            await _plantService.UpdatePlantAsync(updatePlantRequest);
            return NoContent();
        }

        //[Authorize("User,Administrator,Moderator")]
        [HttpDelete("delete-plant")]
        public async Task<IActionResult> DeletePlant(Guid userId, Guid plantId)
        {
            await _plantService.DeletePlantAsync(userId, plantId);
            return NoContent();
        }
    }
}
