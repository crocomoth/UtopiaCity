using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.ViewModels.Sport
{
    public class SportEventViewModel : SportComplexBaseViewModel
    {
        public string SportEventId { get; set; }
        public string SportEventTitle { get; set; }
        public DateTime DateOfTheEvent { get; set; }
    }
}