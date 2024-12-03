using LeafwixServerDAL.Enums;

namespace LeafwixServerDAL.Entities.App
{
    public class PlantCareHistory
    {
        public Guid Id { get; set; }

        // Тип дії (полив, удобрення тощо)
        public CareType CareType { get; set; }

        // Дата дії
        public DateTime ActionDate { get; set; }

        // Зовнішній ключ для рослини
        public Guid PlantId { get; set; }
        public Plant Plant { get; set; }
    }
}
