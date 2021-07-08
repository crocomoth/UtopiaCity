using System;
using System.ComponentModel.DataAnnotations;
using UtopiaCity.Models.Sport.Enums;

namespace UtopiaCity.Models.Sport
{
    /// <summary>
    /// Represents sport complex.
    /// </summary>
    public class SportComplex
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"[^' '][a-zA-Z0-9' ']{1,100}[^' ']", ErrorMessage = "Enter correct title")]
        public string Title { get; set; }

        [Required]
        [Range(1, 100000)]
        public int NumberOfSeats { get; set; }

        [Required]
        public DateTime BuildDate { get; set; }

        [Required]
        public TypesOfSport TypeOfSport { get; set; }

        //TODO Take Address as a class
        /*public Address Address {get;set;}*/
        [Required]
        [RegularExpression(@"[^' '][a-zA-Z0-9' ']{1,100}[^' ']", ErrorMessage = "Enter correct address")]
        public string Address { get; set; }
    }
}
