using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.HousingSystem
{
    public class EstateAddress
    {
        public List<String> District { get; set; }
        public List<String> Street { get; set; }
        public List<int> HouseNumber { get; set; }    
    }
}
