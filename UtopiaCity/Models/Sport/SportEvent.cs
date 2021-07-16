using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Sport
{
    public class SportEvent
    {
        public string SportEventId { get; set; }
        public string Title { get; set; }
        public DateTime DateOfTheEvent { get; set; }
        public SportComplex SportComplex { get; set; }
        
        //TODO: Add Citizen as a subscriber on event
    }
}
