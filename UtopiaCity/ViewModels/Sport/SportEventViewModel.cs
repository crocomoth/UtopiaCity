using System;
using System.ComponentModel.DataAnnotations;

namespace UtopiaCity.ViewModels.Sport
{
    public class SportEventViewModel : SportComplexBaseViewModel
    {
        public string SportEventId { get; set; }

        [Required]
        [RegularExpression(@"[^' ']([A-Za-z0-9]{1,}([' ']{0,1})){1,}[^' ']", ErrorMessage = "Enter correct title")]
        public string SportEventTitle { get; set; }

        [Required]
        public DateTime DateOfTheEvent { get; set; }
    }
}