using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Airport;

namespace UtopiaCity.Services.Airport
{
    public interface IRouteApi
    {
        Task <List<Resource>> GetRouteObject(string locationPoint, string destinationPoint);
    }
}
