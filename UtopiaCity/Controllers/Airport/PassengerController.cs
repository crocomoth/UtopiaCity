using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;
using UtopiaCity.Services.Airport;

namespace UtopiaCity.Controllers.Airport
{
    public class PassengerController : Controller
    {
        private readonly PassengerService _passengerService;
        private readonly TicketService _ticketService;

        public PassengerController(PassengerService service,TicketService ticket)
        {
            _passengerService = service;
            _ticketService = ticket;
        }

        public IActionResult ListOfDeparted()
        {
            return View("ListOfDepartedView", _passengerService.GetListOfPassengers());
        }

        public IActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var passenger = _passengerService.GetPassengerById(id);
            if(passenger is null)
            {
                return NotFound();
            }

            return View("PassengerDetailsView", passenger);
        }

        [HttpGet]
        public IActionResult CreateDepartedPassengers()
        {
            ViewBag.Residents = _ticketService.GetSelectListOfContextResidents("Id", "FirstName");
            return View("CreateDepartedPassengersView");
        }

        [HttpPost]
        public IActionResult CreateDepartedPassengers(Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                _passengerService.AddPassenger(passenger);
                return RedirectToAction(nameof(ListOfDeparted));
            }

            return View("CreateDepartedPassengersView", passenger);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var passenger = _passengerService.GetPassengerById(id);
            if(passenger is null)
            {
                return NotFound();
            }
            return View("PassengerEditView", passenger);
        }

        [HttpPost]
        public IActionResult Edit(string id, Passenger edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _passengerService.UpdatePassenger(edited);
                return RedirectToAction(nameof(Index));
            }

            return View("PassengerEditView", edited);
        }

        [HttpGet]
        public IActionResult Delete (string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var passenger = _passengerService.GetPassengerById(id);
            if(passenger is null)
            {
                return NotFound();
            }

            return View("PassengerDeleteView");
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var passenger = _passengerService.GetPassengerById(id);
            if(passenger is null)
            {
                return NotFound();
            }

            _passengerService.DeletePassenger(passenger);
            return RedirectToAction(nameof(ListOfDeparted));
        }
    }
}
