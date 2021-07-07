using System;
using UtopiaCity.Models.Sport.Enums;

namespace UtopiaCity.Models.Sport
{
    public class SportComplex
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumberOfSeats { get; set; }
        public DateTime BuildDate { get; set; }
        public TypesOfSport TypeOfSport { get; set; }

        //TODO Take Address as a class
        /*public Address Address {get;set;}*/
        public string Address { get; set; }
    }
}
