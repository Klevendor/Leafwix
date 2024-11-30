using LeafwixServerDAL.Entities.Identity;

namespace LeafwixServerDAL.Entities.App
{
    public class Plant
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!; // Ім'я рослини

        public int CurrentHealth { get; set; } // Поточне "хп"
        public int MaxHealth { get; set; } // Максимальне "хп"
        public DateTime LastWatered { get; set; } // Час останнього поливу
        public DateTime NextWateringTime { get; set; } // Наступний рекомендований полив 

        public Guid PlantSpeciesId { get; set; }
        public PlantSpecies PlantSpecies { get; set; } = null!;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

    }
}
