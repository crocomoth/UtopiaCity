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
        public string Description { get; set; }

        [Required]
        public DateTime DateOfRequest { get; set; }

        [Required]
        public bool IsApproved { get; set; }

        [Required]
        public bool IsReviewed { get; set; }

        [Required]
        public string SportComplexId { get; set; }
    }
}
