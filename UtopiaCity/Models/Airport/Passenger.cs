using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.CityAdministration;

namespace UtopiaCity.Models.Airport
{
    public class Passenger
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string PassengerName { get; set; }
        public string ProgressStatus { get; set; }
        public string PassengerStatus { get; set; }

        public string TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public string ResidentAccountId { get; set; }
        public ResidentAccount ResidentAccount { get; set; }
    }
}
