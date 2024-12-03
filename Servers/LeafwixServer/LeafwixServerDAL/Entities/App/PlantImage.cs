using LeafwixServerDAL.Enums;

namespace LeafwixServerDAL.Entities.App
{
    public class PlantImage
    {
        public Guid Id { get; set; }

        // Шлях до зображення
        public string ImagePath { get; set; } = null!;

        // Стан здоров'я рослини, для якого існує зображення
        public Status Status { get; set; }

        // Зовнішній ключ, що вказує на тип рослини
        public Guid PlantSpeciesId { get; set; }

        // Навігаційна властивість для доступу до відповідного типу рослини
        public PlantSpecies PlantSpecies { get; set; } = null!;
    }
}
