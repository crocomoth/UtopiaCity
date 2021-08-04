using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Airport;
using UtopiaCity.Models.Life;

namespace UtopiaCity.Models.TimelineModel.CollectionDataModel
{
    public class CollectionDataModel
    {
        public List<Flight> _flights;
        public List<Event> _events;
        public Flight FlightModel { get; set; }
        public Event EventModel { get; set; }
    }
}
