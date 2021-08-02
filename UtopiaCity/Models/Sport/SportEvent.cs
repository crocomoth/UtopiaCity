﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        
        [Required]
        [DisplayName("Event's title")]
        [RegularExpression(@"[^' ']([A-Za-z0-9]{1,}([' ']{0,1})){1,}[^' ']", ErrorMessage = "Enter correct title")]
        public string Title { get; set; }

        [Required]
        [Range(typeof(DateTime), "1/1/1900", "31/07/2021", ErrorMessage="Enter correct Date")]
        public DateTime DateOfTheEvent { get; set; }

        [ForeignKey("SportComplex")]
        public string SportComplexId { get; set; }
        
        //TODO: Add Citizen as a subscriber on event
    }
}