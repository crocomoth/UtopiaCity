using System;
using UtopiaCity.Models.Sport.Enums;

namespace UtopiaCity.ViewModels.Sport
{
    public class SportComplexViewModel : SportComplexBaseViewModel
    {
        public int NumberOfSeats { get; set; }
        public DateTime BuildDate { get; set; }
        public TypesOfSport TypeOfSport { get; set; }
    }
}