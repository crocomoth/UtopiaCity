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
