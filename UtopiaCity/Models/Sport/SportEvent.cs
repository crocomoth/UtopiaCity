using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.Sport
{
    /// <summary>
    /// Represents sport event.
    /// </summary>
    public class SportEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SportEventId { get; set; }
        public string Title { get; set; }
        public DateTime DateOfTheEvent { get; set; }

        [ForeignKey("SportComplex")]
        public string SportComplexId { get; set; }
        
        //TODO: Add Citizen as a subscriber on event
    }
}
