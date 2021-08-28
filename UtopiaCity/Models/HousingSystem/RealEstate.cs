using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UtopiaCity.Models.CityAdministration;

namespace UtopiaCity.Models.HousingSystem
{
    public class RealEstate
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [Display(Name = "House Street")]
        public string Street { get; set; }
        [Required]
        [Display(Name = "House Number")]
        public string Number { get; set; }
        [ForeignKey("ResidentAccount")]
        [Display(Name = "Owner")]
        public string ResidentAccountId { get; set; }
        public virtual ResidentAccount ResidentAccount { get; set; }
        [Required]
        [Display(Name = "Completion year")]
        public int CompletionYear { get; set; }
        [Display(Name = "Estate type")]
        public RealEstateType EstateType { get; set; }
    }
    public enum RealEstateType
    {
        Apartment = 0,
        PrivateHouse = 1,
        Dormitory = 2
    }
}
