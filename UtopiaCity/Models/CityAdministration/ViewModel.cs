using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UtopiaCity.Models.CityAdministration
{
    public class ViewModel
    {
        public IEnumerable<ResidentAccount> ResidentAccounts { get; set; }

        [Required(ErrorMessage = "Person data can't be empty")]
        public string FirstPersonId { get; set; }

        [Required(ErrorMessage = "Person data can't be empty")]
        public string SecondPersonId { get; set; }

        public string MarriageId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime MarriageDate { get; set; }
    }
}
