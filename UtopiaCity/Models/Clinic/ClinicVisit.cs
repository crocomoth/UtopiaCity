using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.Clinic
{
    /// <summary>
    /// Represents clinic report.
    /// </summary>
    public class ClinicVisit
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Choose whether person is insured or not.
        /// </summary>
        [Required]
        public string Insurance { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DoB { get; set; }

        public long PhoneNumber { get; set; }

        public string Doctor { get; set; }

        /// <summary>
        /// Report test or data.
        /// </summary>
        [Required]
        public string Visit { get; set; }

        /// <summary>
        /// Time when report event happened.
        /// </summary>
        [Required]
        [Display(Name = "Visit Time")]
        public DateTime VisitTime { get; set; }
    }
}
