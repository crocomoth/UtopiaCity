using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport.TransportManagerSystem;

namespace UtopiaCity.Controllers.Airport
{
    //This class was scaffolded automatically by VS, I added some changes and made updations for future contribution
    public class TransportManagersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransportManagersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET Method Index
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TransportManagers.Include(t => t.ForPassenger);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET Method Details 
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportManager = await _context.TransportManagers
                .Include(t => t.ForPassenger)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportManager == null)
            {
                return NotFound();
            }

            return View(transportManager);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ForPassengerId"] = new SelectList(_context.ForPassengers, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeOfOrder,ForPassengerId")] TransportManager transportManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transportManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ForPassengerId"] = new SelectList(_context.ForPassengers, "Id", "Id", transportManager.ForPassengerId);
            return View(transportManager);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportManager = await _context.TransportManagers.FindAsync(id);
            if (transportManager == null)
            {
                return NotFound();
            }
            ViewData["ForPassengerId"] = new SelectList(_context.ForPassengers, "Id", "Id", transportManager.ForPassengerId);
            return View(transportManager);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,TypeOfOrder,ForPassengerId")] TransportManager transportManager)
        {
            if (id != transportManager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transportManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportManagerExists(transportManager.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ForPassengerId"] = new SelectList(_context.ForPassengers, "Id", "Id", transportManager.ForPassengerId);
            return View(transportManager);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportManager = await _context.TransportManagers
                .Include(t => t.ForPassenger)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportManager == null)
            {
                return NotFound();
            }

            return View(transportManager);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var transportManager = await _context.TransportManagers.FindAsync(id);
            _context.TransportManagers.Remove(transportManager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportManagerExists(string id)
        {
            return _context.TransportManagers.Any(e => e.Id == id);
        }

        // GET Methods for Buttons
        public IActionResult GetPassengerDirection() => View("GetPassengerDirectionView");
    
        [HttpGet]
        public IActionResult CreateForPassengerTo()=> View("CreateForPassengerToView");

        [HttpGet]
        public IActionResult CreateForPassengerFrom()=> View("CreateForPassengerFromView");



        [HttpPost]
        public async Task<IActionResult> CreateForPassenger(ForPassenger passenger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passenger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View("CreateForPassengerToView", passenger);
        }

        // TODO: create ForCompany model, add methods to the controller , add new migration "ForCompany" ,
        // add new data-table to the Index view, try to make pagination
    }
}
