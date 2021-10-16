using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess;

namespace UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees
{
    public class EmployeeManagement
    {
        [ScaffoldColumn(false)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required, MaxLength(30)]
        public string FullName { get; set; }

        [RegularExpression("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}")]
        public string PhoneNumber { get; set; }
        //public string Equipment { get; set; }
        public bool CanCheck { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeePosition { get; set; }

        [Required]
        public string PositionId { get; set; }
        public Position Position { get; set; }

        [Required]
        public string DepartmentId { get; set; }
        public FireSafetyDepartment Department { get; set; }
        public List<FireSafetyCheck> Checks { get; set; }
    }
}
