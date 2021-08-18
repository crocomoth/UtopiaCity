using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Services.Airport.Dictionaries
{
    public class PlanesSpeedDictionary
    {
        public  Dictionary<string, int> speed = new Dictionary<string, int>()
        {
            ["PassengerShortLengthAircraft"] = 850,
            ["PassengerAverageLengthAircraft"] = 950,
            ["PassengerGreatLengthAircraft"] = 950,
            ["LiftingCapacityAircraftUpTo20"] = 650,
            ["LiftingCapacityAircraftUpto65"] = 770,
            ["LiftingCapacityAircraftUpTo120"] = 866,
        };
    }
}
