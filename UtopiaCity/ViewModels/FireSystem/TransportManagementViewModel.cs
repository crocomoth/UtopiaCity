using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.ViewModels.FireSystem
{
    public class TransportManagementViewModel
    {
        public string Id { get; set; }
        [MaxLength(30)]
        public string TypeOfFireCar { get; set; }
        public bool FirePump { get; set; }
        public bool ContainerForStoringFireExtinguishingAgents { get; set; }
        [MaxLength(30)]
        public string FireFightingEquipment { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
