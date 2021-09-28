using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.CitizenAccount
{
    /// <summary>
    /// Represent user money transaction.
    /// </summary>
    public class Transaction
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }

        [Required]
        public string Description { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
