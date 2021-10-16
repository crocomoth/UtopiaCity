using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess;

namespace UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees
{
    public class TransportManagement
    {
        [ScaffoldColumn(false)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [MaxLength(30)]
        public string TypeOfFireCar { get; set; }
        public string DepartmentName { get; set; }
        public bool FirePump { get; set; }
        public bool ContainerForStoringFireExtinguishingAgents { get; set; }
        [MaxLength(30)]
        public string FireFightingEquipment { get; set; }
        public string DepartmentId { get; set; }
        public FireSafetyDepartment Department { get; set; }
    }
}
