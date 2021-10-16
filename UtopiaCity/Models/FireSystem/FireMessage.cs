using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.FireSystem
{
    public class FireMessage
    {
        [ScaffoldColumn(false)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("DepartureToThePlace")]
        public string Id { get; set; }

        [Required, MaxLength(30)]
        public string Address { get; set; }

        [Required, MaxLength(30)]
        public string FullName { get; set; }

        [Required, RegularExpression("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}")]
        public string PhoneNumber { get; set; }
        public DepartureToThePlaceOfFire DepartureToThePlace { get; set; }
    }
}
