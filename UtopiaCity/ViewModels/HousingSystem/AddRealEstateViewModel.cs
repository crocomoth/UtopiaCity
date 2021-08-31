using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UtopiaCity.Helpers;
using UtopiaCity.Models.CityAdministration;
using UtopiaCity.Models.HousingSystem;

namespace UtopiaCity.ViewModels.HousingSystem
{
    public class AddRealEstateViewModel
    {
        [Required, MinLength(4, ErrorMessage = "Please enter a valid street name")]
        [Display(Name = "House Street")]
        public string Street { get; set; }
        [Required, MaxLength(7, ErrorMessage = "Please enter a valid house number")]
        [Display(Name = "House Number")]
        public string Number { get; set; }
        [Display(Name = "Owner")]
        public ResidentAccount ResidentAccount { get; set; }
        [Required, RangeUntilCurrentYear(1900, ErrorMessage = "Please enter a valid year")]
        [Display(Name = "Completion year")]
        public int CompletionYear { get; set; }
        [Display(Name = "Estate type")]
        public RealEstateType EstateType { get; set; }
        [Display(Name = "Residents")]
        public ICollection<String> Residents { get; set; }
    }
}

