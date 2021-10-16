using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess;

namespace UtopiaCity.Models.FireSystem
{
    public class DepartureToThePlaceOfFire
    {
        [ScaffoldColumn(false)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required, MaxLength(30)]
        public string Address { get; set; }

        [Required, MaxLength(30)]
        public string FullName { get; set; }

        [Required, RegularExpression("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}")]
        public string PhoneNumber { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public FireSafetyDepartment Department { get; set; }
        public string FireMessageId { get; set; }
        public FireMessage FireMessage { get; set; }
    }
}
