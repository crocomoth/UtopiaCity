using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Sport
{
    public class SportEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SportEventId { get; set; }
        public string Title { get; set; }
        public DateTime DateOfTheEvent { get; set; }
        public string SportComplexId { get; set; }
        
        //TODO: Add Citizen as a subscriber on event
    }
}
