using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.CitizenAccount
{
    public class Transaction
    {
        /// <summary>
        /// Represent money transaction.
        /// </summary>
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Display(Name = "Recipients Username"),Required]
        public string RecipientsUsername { get; set; }

        [Required]
        [Range(1,10000,
        ErrorMessage = "Value for {0} must be more than 1.")]
        public double Amount { get; set; }
        public DateTime ReminderDate { get; set; } = DateTime.Now;
    }
}
