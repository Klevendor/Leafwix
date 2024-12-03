using LeafwixServerDAL.Entities.Identity;

namespace LeafwixServerDAL.Entities.App
{
    public class Plant
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!; // Ім'я рослини
        public double Age { get; set; } // Вік рослини
        public int Health { get; set; } // Поточне "хп"
        
        public DateTime LastWatered { get; set; } // Час останнього поливу
        
        public Guid PlantSpeciesId { get; set; }
        public PlantSpecies PlantSpecies { get; set; } = null!;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        // Навігаційна властивість для історії догляду
        public ICollection<PlantCareHistory> PlantCareHistories { get; set; } = new List<PlantCareHistory>();
    }
}
