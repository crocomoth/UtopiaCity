using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees
{
    public class TransportManagement
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string TypeOfFireCar { get; set; } //enum
        public bool FirePump { get; set; }
        public bool ContainerForStoringFireExtinguishingAgents { get; set; }
        public string FireFightingEquipment { get; set; } // enum
    }
}
