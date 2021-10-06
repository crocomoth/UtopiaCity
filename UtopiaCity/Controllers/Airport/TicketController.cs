using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;
using UtopiaCity.Models.CityAdministration;
using UtopiaCity.Models.TimelineModel;
using UtopiaCity.Services.Airport;

namespace UtopiaCity.Controllers.Airport
{
    [Authorize]
    public class TicketController:Controller
    {
        private readonly TicketService _ticketService;
        public TicketController(TicketService ticket)
        {
            _ticketService = ticket;
        }

        public IActionResult Index()
        {
            return View("TicketsListView", _ticketService.GetTicketsComplex());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Flights = _ticketService.GetSelectListOfContextFlights("Id", "FlightNumber");
            ViewBag.ResidentAccount = _ticketService.GetSelectListOfContextResidents("Id", "FirstName");
            ViewBag.PermitedModel = _ticketService.GetSelectListOfContextPermissions("Id", "PermissionStatus");
            return View("TicketsCreateView");
        }

        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            _ticketService.AddTickets(ticket);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetTicketComplexById(id);
            if (ticket is null)
            {
                return NotFound();
            }
            return View("TicketsDeleteView", ticket);
        }

        [HttpPost, ActionName("TicketsDeleteView")]
        public IActionResult DeleteConfirmed(string id)
        {
            var ticket = _ticketService.FindTicketById(id);
            _ticketService.DeleteTicket(ticket);
            return RedirectToAction(nameof(Index));
        }
    }
}
