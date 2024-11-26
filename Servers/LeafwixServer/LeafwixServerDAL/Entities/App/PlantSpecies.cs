using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        
        public List<Plant> Plants { get; set; }

        // Навігаційна властивість для хвороб рослин
        public List<PlantDiseases> PlantDiseases { get; set; }
    }
}
