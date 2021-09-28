using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UtopiaCity.Models.CitizenAccount
{
    /// <summary>
    /// Represent money transaction to buy something.
    /// </summary>
    public class TransactionToBuyViewModel
    {
        [Display(Name = "Description Of The Purchase"), Required]
        public string DescriptionOfThePurchase { get; set; }

        public int UserBalance { get; set; }

        [Required]
        public int Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
