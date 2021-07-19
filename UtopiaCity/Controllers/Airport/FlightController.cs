using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Models.Airport;
using UtopiaCity.Services.Airport;

namespace UtopiaCity.Controllers.Airport
{
    public class FlightController:Controller
    {
        private FlightService _flightService;

        public FlightController(FlightService flightService)
        {
            _flightService = flightService;
        }

        public IActionResult Index()
        {
            return View("FlightList", _flightService.GetFlightList());
        }

        public IActionResult Details(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return NotFound();
            }

            var flight = _flightService.GetFlightById(id);
            if (flight is null)
            {
                NotFound();
            }

            return View("FlightDetailsView", flight);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("FlightCreateView");
        }

        [HttpPost]
        public IActionResult Create(Flight newFlight)
        {
            if (ModelState.IsValid)
            {
                _flightService.AddFlight(newFlight);
                return RedirectToAction(nameof(Index));
            }

            return View("FlightCreateView", newFlight);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return NotFound();
            }

            var flight = _flightService.GetFlightById(id);
            if (flight is null)
            {
                NotFound();
            }

            return View("FlightEditView", flight);
        }

        [HttpPost]
        public IActionResult Edit(string id, Flight edited)
        {
            if (id != edited.Id.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _flightService.UpdateFlight(edited);
                return RedirectToAction(nameof(Index));
            }

            return View("FlightEditView", edited);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                NotFound();
            }

            var flight = _flightService.GetFlightById(id);
            if (flight is null)
            {
                NotFound();
            }

            return View("FlightDeleteView", flight);
        }

        [HttpPost, ActionName("FlightDeleteView")]
        public IActionResult DeleteConfirmed(int id)
        {
            var flight = _flightService.GetFlightById(id);
            if (flight is null)
            {
                NotFound();
            }

            _flightService.DeleteFlight(flight);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
