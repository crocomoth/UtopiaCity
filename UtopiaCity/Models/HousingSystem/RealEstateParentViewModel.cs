using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.ViewModels.HousingSystem;

namespace UtopiaCity.Models.HousingSystem
{
    public class RealEstateParentViewModel
    {
        public RealEstate RealEstate { get; set; }
        public AddRealEstateViewModel AddRealEstateViewModel {get; set; }
    }
}
