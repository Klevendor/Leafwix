namespace LeafwixServerDAL.Entities.App
{
    public class PlantDiseases
    {
        public Guid Id { get; set; }
        public string DiseaseName { get; set; } // Назва хвороби (наприклад, "Коренева гниль")
        public string Symptoms { get; set; } // Опис симптомів хвороби (жовте листя, гнилі корені тощо).
        public string Causes { get; set; } // Причини виникнення хвороби (переливання води, шкідники).
        public string Treatment { get; set; } // Опис методів лікування (дренаж ґрунту, зміна умов).
        public string Prevention { get; set; } // Запобіжні заходи для уникнення хвороби.

        // Зовнішній ключ для виду рослини
        public Guid? PlantSpeciesId { get; set; }  // Хвороба може бути специфічною для певного виду рослин або універсальною
        public PlantSpecies PlantSpecies { get; set; }
    }
}
