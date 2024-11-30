namespace LeafwixServerDAL.Entities.App
{
    public class PlantSpecies
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // назва рослини
        public string ImageUrl { get; set; } // зображення рослини
        public string Description { get; set; } // короткий опис
        public string WateringFrequency { get; set; } // Як часто поливати рослину (щодня, раз на тиждень тощо)
        public string LightRequirements { get; set; } // Вимоги до освітлення (пряме, непряме, тінь).
        public string SoilType { get; set; } // Тип ґрунту (слабокислий, нейтральний, лужний).

        // Один тип рослини може мати багато зображень
        public ICollection<PlantImage> PlantImages { get; set; } = [];

        public List<Plant> Plants { get; set; } = [];

        // Навігаційна властивість для хвороб рослин
        public List<PlantDiseases> PlantDiseases { get; set; } = [];
    }
}
