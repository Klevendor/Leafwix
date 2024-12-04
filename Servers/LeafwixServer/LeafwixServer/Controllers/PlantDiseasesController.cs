using LeafwixServerBLL.Models;
using LeafwixServerBLL.Services.Implementation;
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


        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var species = await _plantDiseasesService.GetAllAsync();
            return Ok(species);
        }

        [HttpGet("getSingle")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var species = await _plantDiseasesService.GetByIdAsync(id);
            if (species == null) return NotFound();

            return Ok(species);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] PlantDiseaseCreateRequest createDto)
        {
            await _plantDiseasesService.AddAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = createDto.DiseaseName }, createDto);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] PlantDiseaseUpdateRequest updateDto)
        {
            await _plantDiseasesService.UpdateAsync(updateDto);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _plantDiseasesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
