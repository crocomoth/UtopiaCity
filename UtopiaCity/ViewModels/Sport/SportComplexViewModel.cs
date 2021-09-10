using System;
using System.ComponentModel.DataAnnotations;
using UtopiaCity.Models.Sport.Enums;

namespace UtopiaCity.ViewModels.Sport
{
    public class SportComplexViewModel : SportComplexBaseViewModel
    {
        [Required]
        [Range(1, 100000)]
        public int NumberOfSeats { get; set; }

        [Required]
        public DateTime BuildDate { get; set; }

        [Required]
        public TypesOfSport TypeOfSport { get; set; }
    }
}