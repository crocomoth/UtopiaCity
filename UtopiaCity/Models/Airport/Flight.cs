using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Airport
{
    public class Flight
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public int FlightNumber { get; set; }        
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public string DestinationPoint { get; set; }
        public string LocationPoint { get; set; }
        public string TypeOfAircraft { get; set; }
        public string Weather { get; set; }
    }

}
