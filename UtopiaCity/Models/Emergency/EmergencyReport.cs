
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.Emergency
{
    /// <summary>
    /// Represents emergency report.
    /// </summary>
    public class EmergencyReport
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        /// <summary>
        /// Report test or data.
        /// </summary>
        [Required]
        public string Report { get; set; }

        /// <summary>
        /// Time when report event happened.
        /// </summary>
        [Required]
        [Display(Name = "Report Time")]
        public DateTime ReportTime { get; set; }
    }
}