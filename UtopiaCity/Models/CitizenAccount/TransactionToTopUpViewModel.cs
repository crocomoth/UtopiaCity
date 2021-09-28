using System;
using System.ComponentModel.DataAnnotations;

namespace UtopiaCity.Models.CitizenAccount
{
    /// <summary>
    /// Represent money transaction to top up account balance.
    /// </summary>
    public class TransactionToTopUpViewModel
    {
        [Display(Name = "Recipients Username"),Required]
        public string RecipientsUsername { get; set; }

        [Required]
        public int Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
