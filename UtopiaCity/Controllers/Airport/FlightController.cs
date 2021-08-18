using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;
using UtopiaCity.Services.Airport;
using UtopiaCity.Utils;

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

        public IActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
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
            var dictionaryData = _flightService.GetListOfPlaneTypes();
            ViewData["TypeOfAircraft"] = new SelectList(dictionaryData);
            return View("FlightCreateView");
        }

        [HttpPost]
        public IActionResult Create(Flight newFlight)
        {
            if (ModelState.IsValid)
            {
                newFlight.FlightNumber = RandomUtil.GenerateRandomString(150).ElementAtOrDefault(10);
                var arrivalTime = _flightService.GetArrivalTime(newFlight.DepartureTime, newFlight.LocationPoint, newFlight.DestinationPoint, newFlight.TypeOfAircraft);
                newFlight.ArrivalTime = arrivalTime;
                _flightService.AddFlight(newFlight);
                return RedirectToAction(nameof(Index));
            }

            return View("FlightCreateView", newFlight);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
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
            if (id != edited.Id)
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

        // ToDo: Add jquery/ajax request to the View of the Edit method, 
        // for making travel time data in the form dynamically changeable


        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
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
        public IActionResult DeleteConfirmed(string id)
        {
            var flight = _flightService.GetFlightById(id);
            if (flight is null)
            {
                NotFound();
            }

            _flightService.DeleteFlight(flight);
            return RedirectToAction(nameof(Index));
        }

        //[HttpGet]
        //public IActionResult GetDistanceByApi()
        //{
        //    return View("GetDistanceByApiView");
        //}

        //[HttpPost]
        //public async Task<IActionResult> GetDistanceByApi(Flight newFlight)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        newFlight.FlightNumber = _flightService.GetRandomFlightNumber();
        //         _flightService.AddFlight(newFlight);
        //        //var apiData= await _routeService.GetRouteObject(newFlight.LocationPoint, newFlight.DestinationPoint);                
        //        //ViewData["FlightApiId"] = new SelectList((System.Collections.IEnumerable)apiData, "Id", "Id");
        //        return View("GetListApiDataView");
        //    }

        //    return View("GetDistanceByApiView", newFlight);
        //}
    }
}
