using LeafwixServerDAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafwixServerBLL.Models
{
    public class PlantCareHistoryResponse
    {
        public Guid Id { get; set; }
        public CareType CareType { get; set; }
        public DateTime ActionDate { get; set; }
        public string PlantName { get; set; } = string.Empty; // Додаткове поле для імені рослини
    }
    public class PlantCareHistoryRequest
    {
        public Guid UserId { get; set; }
        public string CareType { get; set; }
    }


    public class PlantCareHistoryCreateRequest
    {
        public string CareType { get; set; }
        public Guid PlantId { get; set; }
        public Guid UserId { get; set; }
    }

}
