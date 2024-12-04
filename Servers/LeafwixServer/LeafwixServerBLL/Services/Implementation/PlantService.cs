using LeafwixServerBLL.Models;
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

                return new PlantListResponse(plant.Id, plant.Name, plant.Age, imageUrl, plant.PlantSpecies.Name, plant.Health);
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
                LastWatered = DateTime.Now.ToUniversalTime(),
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

            string size = "";
            if (status == Status.Small)
            {
                size = "small";
            }
            else if (status == Status.Medium)
            {
                size = "medium";
            }
            else
            {
                size = "big";
            }

            string species = "";
            if (plant.PlantSpecies.Name == "African Violet (Saintpaulia ionantha)")
            {
                species = "african_violet";
            }
            else if (plant.PlantSpecies.Name == "Cast Iron Plant (Aspidistra elatior)")
            {
                species = "aspidistra_elatior";
            }
            else if (plant.PlantSpecies.Name == "Aloe Vera")
            {
                species = "aloe_vera";
            }
            else if (plant.PlantSpecies.Name == "Dracaena")
            {
                species = "dracaena_fragrans";
            }
            else
            {
                species = "default_plant";
            }

            return $"/{size}_{species}.svg";
        }

        // Визначення статусу здоров'я рослини
        private Status GetStatus(double health)
        {
            if (health <= 3)
            {
                return Status.Small;
            }
            else if (health >= 3 && health < 5)
            {
                return Status.Medium;
            }
            else
            {
                return Status.Big;
            }
        }
    }
}
