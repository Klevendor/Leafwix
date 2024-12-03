using LeafwixServerBLL.Models;
using LeafwixServerBLL.Services.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace LeafwixServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantSpeciesController : ControllerBase
    {
        private readonly IPlantSpeciesService _plantSpeciesService;

        public PlantSpeciesController(IPlantSpeciesService plantSpeciesService)
        {
            _plantSpeciesService = plantSpeciesService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var species = await _plantSpeciesService.GetAllAsync();
            return Ok(species);
        }

        [HttpGet("getSingle")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var species = await _plantSpeciesService.GetByIdAsync(id);
            if (species == null) return NotFound();

            return Ok(species);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] PlantSpeciesCreateRequest createDto)
        {
            await _plantSpeciesService.AddAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = createDto.Name }, createDto);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] PlantSpeciesUpdateRequest updateDto)
        {
            await _plantSpeciesService.UpdateAsync(updateDto);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _plantSpeciesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
