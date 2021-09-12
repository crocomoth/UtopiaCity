using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Airport.TransportManagerSystem;

namespace UtopiaCity.Models.Airport
{
    public class AirportWarehouse
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string LuggageType { get; set; }
        public string LuggageWeight { get; set; }
        public string Status { get; set; }
        public string HostName { get; set; }

        public string ForPassengerId { get; set; }
        public ForPassenger ForPassenger { get; set; }
    }
}
