using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;

namespace UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess
{
    public class FireSafetyDepartment
    {
        [ScaffoldColumn(false)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Сhief { get; set; }
        public DepartmentStatusEnum DepartmentStatusEnum { get; set; }
        //public string TypeOfFireCar { get; set; }
        //public string EmployeeEquipment { get; set; }
        public List<EmployeeManagement> Employees { get; set; }
        public List<TransportManagement> Transports { get; set; }
        public List<DepartureToThePlaceOfFire> DepartureToThePlaces { get; set; }
    }
}
