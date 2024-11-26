using LeafwixServerDAL.Entities.Identity;

namespace LeafwixServerDAL.Entities.App
{
    public class Plant
    {
        public Guid Id { get; set; }
        public string OwnPlantImage { get; set; } // Зображення власної рослини( за замовчуванням відображається цього виду ролини з PlantSpecies)
        
        
        public Guid PlantSpeciesId { get; set; }
        public PlantSpecies PlantSpecies { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
