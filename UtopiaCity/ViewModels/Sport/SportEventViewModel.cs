using System;
using System.ComponentModel.DataAnnotations;

namespace UtopiaCity.ViewModels.Sport
{
    public class SportEventViewModel : SportComplexBaseViewModel
    {
        public string SportEventId { get; set; }
        [Required]
        public string SportEventTitle { get; set; }
        public DateTime DateOfTheEvent { get; set; }
    }
}