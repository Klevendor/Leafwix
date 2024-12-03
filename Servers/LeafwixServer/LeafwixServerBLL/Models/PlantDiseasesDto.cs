namespace LeafwixServerBLL.Models
{
    /* Request Models  */
    public class PlantDiseaseCreateRequest
    {
        public string DiseaseName { get; set; }
        public string Symptoms { get; set; }
        public string Causes { get; set; }
        public string Treatment { get; set; }
        public string Prevention { get; set; }
        public Guid? PlantSpeciesId { get; set; }
    }

    public class PlantDiseaseUpdateRequest
    {
        public Guid Id { get; set; }
        public string DiseaseName { get; set; }
        public string Symptoms { get; set; }
        public string Causes { get; set; }
        public string Treatment { get; set; }
        public string Prevention { get; set; }
    }

    /* Response Models */
    public class PlantDiseaseResponse
    {
        public Guid Id { get; set; }
        public string DiseaseName { get; set; }
        public string Symptoms { get; set; }
        public string Causes { get; set; }
        public string Treatment { get; set; }
        public string Prevention { get; set; }
        public Guid? PlantSpeciesId { get; set; }
    }
}