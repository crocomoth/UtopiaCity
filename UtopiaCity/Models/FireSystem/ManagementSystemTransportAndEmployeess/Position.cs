using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;

namespace UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess
{
    public class Position
    {
        [ScaffoldColumn(false)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public List<EmployeeManagement> Employees { get; set; }
    }
}
