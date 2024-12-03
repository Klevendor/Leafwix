namespace LeafwixServerDAL.Entities.App
{
    public class PlantSpecies
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // назва рослини
        public string Description { get; set; } // короткий опис
        public string Watering { get; set; } // Як часто поливати рослину 
        public string Lighting { get; set; } // Вимоги до освітлення .
        public string SoilType { get; set; } // Тип ґрунту.
        public string Humidity { get; set; } // Вимоги до вологості 
        public string Temperature { get; set; } // Вимоги до температури


        // Масив або список цікавих фактів
        public List<string> InterestingFacts { get; set; } = new List<string>();

        // Один тип рослини може мати багато зображень
        public ICollection<PlantImage> PlantImages { get; set; } = [];

        public List<Plant> Plants { get; set; } = [];

        // Навігаційна властивість для хвороб рослин
        public List<PlantDiseases> PlantDiseases { get; set; } = [];
    }
}
