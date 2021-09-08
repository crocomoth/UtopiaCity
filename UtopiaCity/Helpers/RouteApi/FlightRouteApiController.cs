using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;
using UtopiaCity.Services.Airport;

namespace UtopiaCity.Helpers.RouteApi
{
    public class FlightRouteApiController : Controller
    {
        private readonly FlightRouteApiService _service;
        private readonly ApplicationDbContext _dbCnotext;
        public FlightRouteApiController(FlightRouteApiService service, ApplicationDbContext context)
        {
            _service = service;
            _dbCnotext = context;
        }

        [HttpGet("DistanceMatrix")]
        public async Task<List<Resource>> GetRoute()
        {
            var flightModel = _dbCnotext.Flights;
            if(flightModel is null)
            {
                return null;
            }
            var rootData = await _service.GetRouteObject(flightModel.FirstOrDefault().LocationPoint,
                                                         flightModel.FirstOrDefault().DestinationPoint);
            if(rootData != null)
            {
                return rootData.ToList();
            }

            return null;
        }
    }
}
