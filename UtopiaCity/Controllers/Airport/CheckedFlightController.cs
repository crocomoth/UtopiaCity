using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Airport;
using UtopiaCity.Services.Airport;

namespace UtopiaCity.Controllers
{
    public class CheckedFlightController : Controller
    {
        private readonly CheckedFlightService _checkingService;
        private readonly FlightService _flightService;
        public CheckedFlightController(CheckedFlightService checkedFlight, FlightService service)
        {
            _checkingService = checkedFlight;
            _flightService = service;
        }

        public IActionResult Index()
        {
            return View(_checkingService.GetCheckedFlightList());
        }

        [HttpPost]
        public IActionResult Dispatcher(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var existingFlight = _flightService.GetFlightById(id);
            if (existingFlight is null)
            {
                return NotFound();
            }

            var checkedFlight = _checkingService.CheckFlightByWeatherReport(existingFlight);
            _checkingService.AddCheckedFlight(checkedFlight);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var model = _checkingService.GetCheckedFlightById(id);
            if(model is null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var checkedModel = _checkingService.GetCheckedFlightById(id);
            if(checkedModel is null)
            {
                return NotFound();
            }

            _checkingService.DeleteCheckedFlight(checkedModel);
            return RedirectToAction(nameof(Index));
        }
    }
}
