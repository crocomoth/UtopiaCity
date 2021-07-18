using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.HousingSystem
{
    public class RealEstate
    {
        public string Id { get; set; }
        public EstateType Type { get; set; }
        public string Address { get; set; }
        public string Owner { get; set; }
        public List<Resident> Residents { get; set; }
    }
}
