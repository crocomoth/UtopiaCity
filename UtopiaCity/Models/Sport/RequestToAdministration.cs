using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.Sport
{
    /// <summary>
    /// Represents requests to administration.
    /// </summary>
    public class RequestToAdministration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [RegularExpression(@"[^' ']([A-Za-z0-9]{1,}([' ']{0,1})){1,}[^' ']", ErrorMessage = "Enter correct title")]
        public string Description { get; set; }

        [Required]
        public DateTime DateOfRequest { get; set; }

        [Required]
        public bool IsApproved { get; set; }

        [Required]
        public bool IsReviewed { get; set; }

        [ForeignKey("SportComplex")]
        public string SportComplexId { get; set; }
        public SportComplex SportComplex { get; set; }
    }
}
