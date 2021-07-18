using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        public string Destination { get; set; }
        public string Weather { get; set; }
    }
}
