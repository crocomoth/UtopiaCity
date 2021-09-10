using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;

namespace UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess
{
    public class FireSafetyDepartment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Сhief { get; set; }
        public string DepartmentStatusId { get;set; }
        public DepartmentStatus DepartmentStatus { get; set; }
        public ICollection<EmployeeManagement> Employees { get; set; }
        public ICollection<TransportManagement> Transports { get; set; }
    }
}
