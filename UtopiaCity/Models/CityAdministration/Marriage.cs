using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.CityAdministration
{
    public class Marriage
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public string FirstPersonId { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public string SecondPersonId { get; set; }
        public string FirstPersonData { get; set; }
        public string SecondPersonData { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime MarriageDate { get; set; }
    }
}
