﻿using LeafwixServerBLL.Models;
using LeafwixServerBLL.Services.Interfaces;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Enums;
using LeafwixServerDAL.Repositories.Interfaces;
using System.Linq;

namespace LeafwixServerBLL.Services.Implementation
{
    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _repository;

        public PlantService(IPlantRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PlantListResponse>> GetAllPlantsAsync(Guid userId)
        {
            var plants = await _repository.GetAllPlantsAsync(userId);

            return plants.Select(plant =>
            {
                var status = GetStatus(plant.Age);
                var imageUrl = GetPlantImage(plant, status);

                return new PlantListResponse(plant.Id, plant.Name, plant.Age, imageUrl, plant.Health);
            }).ToList();
        }

        public async Task<PlantResponse?> GetPlantAsync(Guid userId, Guid plantId)
        {
            var plant = await _repository.GetPlantAsync(userId, plantId);
            if (plant == null) return null;
            var status = GetStatus(plant.Age);
            var imageUrl = GetPlantImage(plant, status);
            return new PlantResponse(plant.Id, plant.Name, plant.Age, imageUrl, plant.Health);
        }

        public async Task AddPlantAsync(AddPlantRequest addPlantRequest)
        {
            var plant = new Plant
            {
                Id = Guid.NewGuid(),
                Name = addPlantRequest.Name,
                Age = addPlantRequest.Age,
                Health = 100,
                LastWatered = DateTime.Now,
                PlantSpeciesId = addPlantRequest.PlantSpeciesId,
                UserId = addPlantRequest.UserId
            };

            await _repository.AddAsync(plant);
        }

        public async Task UpdatePlantAsync(UpdatePlantRequest updatePlantRequest)
        {
            var plant = await _repository.GetPlantAsync(updatePlantRequest.UserId, updatePlantRequest.PlantSpeciesId);
            if (plant == null) throw new Exception("Plant not found");

            plant.Name = updatePlantRequest.Name;
            plant.Age = updatePlantRequest.Age;
            plant.Health = updatePlantRequest.Health;

            await _repository.UpdateAsync(plant);
        }

        public async Task DeletePlantAsync(Guid userId, Guid plantId)
        {
            var plant = await _repository.GetPlantAsync(userId, plantId);
            if (plant == null) throw new Exception("Plant not found");

            await _repository.DeleteAsync(plant);
        }

        /* Допоміжні методи */

        private string GetPlantImage(Plant plant, Status status)
        {
            var image = plant.PlantSpecies.PlantImages.FirstOrDefault(img => img.Status == status);
            if (image == null)
            {
                return $"/images/default_plant{status}.png"; // Default image
            }

            return image.ImagePath;
        }

        // Визначення статусу здоров'я рослини
        private Status GetStatus(double health)
        {
            return health switch
            {
                >= 5 => Status.Big,
                >= 3 => Status.Medium,
                >= 1 => Status.Small,
                _ => Status.Dead
            };
        }
    }
}
