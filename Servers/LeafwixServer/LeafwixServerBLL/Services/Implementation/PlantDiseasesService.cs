using LeafwixServerBLL.Models;
using LeafwixServerBLL.Services.Interfaces;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Repositories.Interfaces;

namespace LeafwixServerBLL.Services.Implementation
{
    public class PlantDiseasesService : IPlantDiseasesService
    {
        private readonly IPlantDiseasesRepository _repository;

        public PlantDiseasesService(IPlantDiseasesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PlantDiseaseResponse>> GetAllAsync()
        {
            var diseases = await _repository.GetAllAsync();

            return diseases.Select(ps => new PlantDiseaseResponse
            {
                Id = ps.Id,
                DiseaseName = ps.DiseaseName,
                Symptoms = ps.Symptoms,
                Causes = ps.Causes,
                Treatment = ps.Treatment,
                Prevention = ps.Prevention,
                PlantSpeciesId = ps.PlantSpeciesId
            }).ToList();
        }


        public async Task<PlantDiseaseResponse> GetByIdAsync(Guid id)
        {
            var disease = await _repository.GetByIdAsync(id);
            if (disease == null) return null;
            return new PlantDiseaseResponse
            {
                Id = disease.Id,
                DiseaseName = disease.DiseaseName,
                Symptoms = disease.Symptoms,
                Causes = disease.Causes,
                Treatment = disease.Treatment,
                Prevention = disease.Prevention,
                PlantSpeciesId = disease.PlantSpeciesId
            };
        }

        public async Task AddAsync(PlantDiseaseCreateRequest plantDiseaseCreateRequest)
        {
            if (plantDiseaseCreateRequest == null) throw new ArgumentNullException("ArgumentNullException");

            var disease = new PlantDiseases
            {
                Id = Guid.NewGuid(),
                DiseaseName = plantDiseaseCreateRequest.DiseaseName,
                Symptoms = plantDiseaseCreateRequest.Symptoms,
                Causes = plantDiseaseCreateRequest.Causes,
                Treatment = plantDiseaseCreateRequest.Treatment,
                Prevention = plantDiseaseCreateRequest.Prevention,
                PlantSpeciesId = plantDiseaseCreateRequest.PlantSpeciesId
            };
            await _repository.AddAsync(disease);
        }

        public async Task UpdateAsync(PlantDiseaseUpdateRequest disease)
        {
            if (disease == null) throw new ArgumentNullException();
            var updated_disease = new PlantDiseases
            {
                Id = disease.Id,
                DiseaseName = disease.DiseaseName,
                Symptoms = disease.Symptoms,
                Causes = disease.Causes,
                Treatment = disease.Treatment,
                Prevention = disease.Prevention
            };
            await _repository.UpdateAsync(updated_disease);
        }

        public async Task DeleteAsync(Guid id)
        {
            var disease = await _repository.GetByIdAsync(id);
            if (disease == null) throw new ArgumentNullException(nameof(disease));

            await _repository.DeleteAsync(disease);
        }
    }
}
