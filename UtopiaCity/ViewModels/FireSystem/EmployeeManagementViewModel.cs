using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.ViewModels.FireSystem
{
    public class EmployeeManagementViewModel
    {
        public string Id { get; set; }

        [Required, MaxLength(30)]
        public string FullName { get; set; }

        [RegularExpression("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}")]
        public string PhoneNumber { get; set; }
        //public string Equipment { get; set; }
        public bool CanCheck { get; set; }
        public string EmployeePosition { get; set; }

        [Required]
        public string Positionid { get; set; }

        [Required]
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        //public ICollection<FireSafetyCheck> Checks { get; set; }
    }
}
