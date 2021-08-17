using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.CityAdministration
{
    public class ResidentAccount
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string FamilyName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }

        [ScaffoldColumn(false)]
        public string MarriageId { get; set; }
        public Marriage Marriage { get; set; }
    }
}
