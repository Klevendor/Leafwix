namespace LeafwixServerBLL.Models
{
    /* Request Models  */
    public class PlantSpeciesCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Watering { get; set; }
        public string Lighting { get; set; }
        public string SoilType { get; set; }
        public string Humidity { get; set; }
        public string Temperature { get; set; }
    }

    public class PlantSpeciesUpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Watering { get; set; }
        public string Lighting { get; set; }
        public string SoilType { get; set; }
        public string Humidity { get; set; }
        public string Temperature { get; set; }
    }

    /* Response Models */
    public class PlantSpeciesResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Watering { get; set; }
        public string Lighting { get; set; }
        public string SoilType { get; set; }
        public string Humidity { get; set; } 
        public string Temperature { get; set; }
    }
}
