using System.Collections.Generic;
using UtopiaCity.Models.Airport;

namespace UtopiaCity.Models.TimelineModel.CollectionDataModel
{
    public class MultipleModel
    {
        public IEnumerable<Flight> EnumerableFlight { get; set; }
        public IEnumerable<Flight> Flight { get; set; }
    }
}


