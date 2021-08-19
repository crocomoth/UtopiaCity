using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;

namespace UtopiaCity.Controllers.Airport
{
    public class TicketController:Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public TicketController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            var ticket = _dbContext.Tickets.Include(t => t.Flight).Include(t => t.PermitedModel).Include(t => t.ResidentAccount);
            return View("TicketsListView", ticket.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            SelectList flights = new SelectList(_dbContext.Flights, "Id", "FlightNumber");
            SelectList accounts = new SelectList(_dbContext.ResidentAccount, "Id", "FirstName");
            SelectList permissions = new SelectList(_dbContext.PermitedModel, "Id", "PermissionStatus");
            ViewBag.Flights = flights;
            ViewBag.ResidentAccount = accounts;
            ViewBag.PermitedModel = permissions;
            return View("TicketsCreateView");
        }

        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var ticket = _dbContext.Tickets
                                           .Include(t => t.Flight)
                                           .Include(t => t.PermitedModel)
                                           .Include(t => t.ResidentAccount)
                                           .FirstOrDefault(m => m.Id == id);
            if (ticket is null)
            {
                return NotFound();
            }
            return View("TicketsDeleteView", ticket);
        }

        [HttpPost, ActionName("TicketsDeleteView")]
        public IActionResult DeleteConfirmed(string id)
        {
            var ticket = _dbContext.Tickets.Find(id);
            _dbContext.Tickets.Remove(ticket);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
