using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UtopiaCity.Models.CitizenAccount
{
    public class CitizensTask
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public string Description { get; set; }
        public DateTime ReminderDate { get; set; }
    }
}
