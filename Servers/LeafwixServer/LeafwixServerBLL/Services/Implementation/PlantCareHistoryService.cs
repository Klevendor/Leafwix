using LeafwixServerBLL.Models;
using LeafwixServerBLL.Services.Interfaces;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Enums;
using LeafwixServerDAL.Repositories.Interfaces;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafwixServerBLL.Services.Implementation
{
    public class PlantCareHistoryService : IPlantCareHistoryService
    {
        private readonly IPlantCareHistoryRepository _plantCareHistoryRepository;
        private readonly IPlantRepository _plantRepository;


        public PlantCareHistoryService(IPlantCareHistoryRepository plantCareHistoryRepository, IPlantRepository plantRepository)
        {
            _plantCareHistoryRepository = plantCareHistoryRepository;
            _plantRepository = plantRepository;

        }

        public async Task<List<PlantCareHistoryResponse>> GetPlantCareHistoryAsync(Guid userId, string careType)
        {
            // Перетворення careType з string в enum
            if (Enum.TryParse<CareType>(careType, true, out var parsedCareType))
            {
                var history = await _plantCareHistoryRepository.GetPlantCareHistoryAsync(userId, parsedCareType);

                // Перетворюємо на DTO
                return history.Select(h => new PlantCareHistoryResponse
                {
                    Id = h.Id,
                    CareType = h.CareType,
                    ActionDate = h.ActionDate,
                    PlantName = h.Plant.Name
                }).ToList();
            }

            throw new ArgumentException($"Invalid care type: {careType}");
        }

        public async Task AddPlantCareHistoryAsync(PlantCareHistoryCreateRequest dto)
        {
            // Перевірка, чи рослина належить користувачу
            var plant = await _plantRepository.GetPlantAsync(dto.UserId, dto.PlantId);
            if (plant == null)
            {
                throw new ArgumentException("Plant not found or doesn't belong to the user");
            }
            // Перетворюємо рядок в enum CareType
            if (!Enum.TryParse<CareType>(dto.CareType, true, out var careType))
            {
                throw new ArgumentException($"Invalid care type: {dto.CareType}");
            }
            // Створення нового запису догляду
            var plantCareHistory = new PlantCareHistory
            {
                Id = Guid.NewGuid(),
                ActionDate = DateTime.Now.ToUniversalTime(),
                CareType = careType,
                PlantId = dto.PlantId
            };

            // Додавання до бази
            await _plantCareHistoryRepository.AddAsync(plantCareHistory);

        }

    }
}
