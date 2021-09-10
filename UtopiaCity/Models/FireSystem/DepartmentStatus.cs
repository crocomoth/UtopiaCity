using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess;

namespace UtopiaCity.Models.FireSystem
{
    public class DepartmentStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<FireSafetyDepartment> Departments { get; set; }
    }
}
