using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.CitizenAccount
{
    /// <summary>
    /// Represents citizens Task.
    /// </summary>
    public class CitizensTask
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Reminder Date")]
        public DateTime ReminderDate { get; set; }
    }
}
