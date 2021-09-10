using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;

namespace UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess
{
    public class Position
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeManagement> Employees { get; set; }
    }
}
