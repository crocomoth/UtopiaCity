using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Life
{
    public class Event
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Event Type")]
        public int EventType { get; set; } //use EventType enums 0-3
    }
    public enum EventType 
    {
        Unknown,
        Sport, 
        Weather,
        News
    }
}
