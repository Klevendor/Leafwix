using LeafwixServerBLL.Models;
using LeafwixServerBLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;

namespace LeafwixServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantCareHistoryController : ApiController
    {
        private readonly IPlantCareHistoryService _plantCareHistoryService;

        public PlantCareHistoryController(IPlantCareHistoryService plantCareHistoryService)
        {
            _plantCareHistoryService = plantCareHistoryService;
        }

        [HttpPost("gethistory")]
        public async Task<IActionResult> GetPlantCareHistory([FromBody] PlantCareHistoryRequest request)
        {
            var history = await _plantCareHistoryService.GetPlantCareHistoryAsync(request.UserId, request.CareType);
            return Ok(history);
        }

        // Запит для додавання нового запису догляду
        [HttpPost("add")]
        public async Task<IActionResult> AddPlantCareHistory([FromBody] PlantCareHistoryCreateRequest dto)
        {
            await _plantCareHistoryService.AddPlantCareHistoryAsync(dto);
            return StatusCode(201, "Plant care history added successfully");
        }
    }
}
