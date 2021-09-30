using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;
using UtopiaCity.Services.Airport;
using UtopiaCity.Services.CityAdministration;

namespace UtopiaCity.Controllers.Airport
{
    public class PassengerController : Controller
    {
        private readonly PassengerService _passengerService;
        private readonly TicketService _ticketService;
        private readonly ResidentAccountService _residentService;

        public PassengerController(PassengerService service,TicketService ticket,ResidentAccountService residentService)
        {
            _passengerService = service;
            _ticketService = ticket;
            _residentService = residentService;
        }

        public IActionResult ListOfDeparted() => View("ListOfDepartedView", _passengerService.GetListOfPassengers());

        public IActionResult ListOfArrivals() => View("ListOfArrivalsView", _passengerService.GetArrivingPassengers());

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
        public IActionResult DetailsArrived(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var arrived = _passengerService.GetArrivingPassengerById(id);
            if(arrived is null)
            {
                return NotFound();
            }

            return View("DetailsArrivedView", arrived);
        }

        [HttpPost,ActionName("DetailsArrived")]
        public IActionResult DetailsArrivedConfirmation(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var passenger = _passengerService.GetArrivingPassengerById(id);
            if (ModelState.IsValid)
            {                
                var newResident = _passengerService.GetNewResidentFromArrivedPassegers(passenger);
                _residentService.AddResidentAccount(newResident).GetAwaiter().GetResult();
                return RedirectToAction(nameof(ListOfArrivals));
            }

            return View("DetailsArrivedView", passenger);
        }


        [HttpGet]
        public IActionResult CreateArrivingPassengers()
        {
            return View("CreateArrivingPassengersView");
        }

        [HttpPost]
        public IActionResult CreateArrivingPassengers(ArrivingPassenger arriving)
        {
            if (ModelState.IsValid)
            {
                _passengerService.AddArrivingPassenger(arriving);
                return RedirectToAction(nameof(ListOfArrivals));
            }

            return View("CreateArrivingPassengersView", arriving);
        }

        [HttpGet]
        public IActionResult CreateDepartedPassengers()
        {
            ViewBag.Residents = _ticketService.GetSelectListOfContextResidents("Id", "FirstName");
            ViewBag.Tickets = new SelectList(_ticketService.GetTicketsComplex(), "Id", "Id");
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

            ViewData["ResidentAccountId"] = new SelectList(_residentService.GetResidentAccounts()
                                                        .GetAwaiter().GetResult(), "FirstName", "FirstName");
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
                return RedirectToAction(nameof(ListOfDeparted));
            }

            return View("PassengerEditView", edited);
        }
        [HttpGet]
        public IActionResult DeleteArrivingPassengers(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var arrived = _passengerService.GetArrivingPassengerById(id);
            if(arrived is null)
            {
                return NotFound();
            }

            return View("DeleteArrivingPassengersView", arrived);
        }

        [HttpPost,ActionName("DeleteArrivingPassengers")]
        public IActionResult DeleteArrivingPassengersConfirm(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var arrived = _passengerService.GetArrivingPassengerById(id);
            _passengerService.DeleteArrivingPassenger(arrived);
            return RedirectToAction(nameof(ListOfArrivals));
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

            return View("PassengerDeleteView", passenger);
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
