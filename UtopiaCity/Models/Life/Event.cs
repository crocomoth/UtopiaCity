using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Life
{
    public class Event
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Event Type")]
        public int EventType { get; set; }
    }
    public enum EventType 
    {
        Unknown,
        Sport, 
        Weather,
        News
    }
}
