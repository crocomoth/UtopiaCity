using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UtopiaCity.Data;
using UtopiaCity.Models.TimelineModel.CollectionDataModel;
using UtopiaCity.Services.Airport;

namespace UtopiaCity.Controllers.Timeline
{
    public class ScheduleController : Controller
    {
        private readonly FlightService _flightService;

        public ScheduleController(FlightService flightService)
        {
            _flightService = flightService;
        }

        public ViewResult Index(string name) => View("Index", new MultipleModel
        {
            Flight = (System.Collections.Generic.IEnumerable<Models.Airport.Flight>)((System.Collections.Generic.IEnumerable<Models.Airport.Flight>)_flightService.GetFlightList())
            .Where(i => i.Weather == name)
            .OrderBy(i => i.Id)
        });
    }
}
