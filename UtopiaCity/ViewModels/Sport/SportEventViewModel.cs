using System;

namespace UtopiaCity.ViewModels.Sport
{
    public class SportEventViewModel : SportComplexBaseViewModel
    {
        public string SportEventId { get; set; }
        public string SportEventTitle { get; set; }
        public DateTime DateOfTheEvent { get; set; }
    }
}