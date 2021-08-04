using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Life
{
    public class EventDto
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        [Display(Name = "Event Type")]
        public int? EventType { get; set; }
        [Display(Name = "Searching Word")]
        public string SearchWord { get; set; }
    }
}