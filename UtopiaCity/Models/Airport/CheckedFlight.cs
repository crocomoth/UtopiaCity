using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Airport
{
    public class CheckedFlight
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public int CheckedFlightNumber { get; set; }
        public DateTime CheckedArrivalTime { get; set; }
        public DateTime CheckedDepartureTime { get; set; }
        public string CheckedDestinationPoint { get; set; }
        public string CheckedLocationPoint { get; set; }
        public string CheckedTypeOfAircraft { get; set; }
        public string CheckedWeather { get; set; }
        public string CheckedFlightWeather { get; set; }
    }
}
