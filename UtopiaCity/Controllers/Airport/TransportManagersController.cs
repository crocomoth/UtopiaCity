using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;
using UtopiaCity.Models.Airport.TransportManagerSystem;

namespace UtopiaCity.Controllers.Airport
{
    [Authorize]
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
            var applicationDbContext = _context.TransportManagers.Include(t => t.ForPassenger).Include(t=>t.ForCompany);
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
                .Include(t=>t.ForCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportManager == null)
            {
                return NotFound();
            }

            return PartialView("DetailsPartialView", transportManager);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ForPassengerId"] = new SelectList(_context.ForPassengers, "Id", "Id");
            ViewData["ForCompanyId"] = new SelectList(_context.ForCompanies, "Id", "Id");
            return PartialView("CreatePartialView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeOfOrder,ForPassengerId,ForCompanyId")] TransportManager transportManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transportManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ForPassengerId"] = new SelectList(_context.ForPassengers, "Id", "Id", transportManager.ForPassengerId);
            ViewData["ForCompanyId"] = new SelectList(_context.ForCompanies, "Id", "Id", transportManager.ForCompanyId);
            return PartialView("CreatePartialView", transportManager);
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
            ViewData["ForCompanyId"] = new SelectList(_context.ForCompanies, "Id", "Id", transportManager.ForCompanyId);
            return PartialView("EditPartialView", transportManager);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,TypeOfOrder,ForPassengerId,ForCompanyId")] TransportManager transportManager)
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
            ViewData["ForCompanyId"] = new SelectList(_context.ForCompanies, "Id", "Id", transportManager.ForCompanyId);
            return PartialView("EditPartialView", transportManager);
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
                .Include(t=>t.ForCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportManager == null)
            {
                return NotFound();
            }

            return PartialView("DeletePartialView", transportManager);
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

        public IActionResult GetCompanyDirection() => View("GetCompanyDirectionView");
    
        [HttpGet]
        public IActionResult CreateForPassengerTo()=> View("CreateForPassengerToView");

        [HttpGet]
        public IActionResult CreateForPassengerFrom()=> View("CreateForPassengerFromView");

        [HttpGet]
        public IActionResult CreateForCompanyTo() => View("CreateForCompanyToView");
        [HttpGet]
        public IActionResult CreateForCompanyFrom() => View("CreateForCompanyFromView");


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

        public async Task<IActionResult> CreateForCompany(ForCompany company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View("CreateForCompanyToView", company);
        }
        // TODO: add new data-table to the Index view 

        public async Task<IActionResult> IndexLuggage()
        {
            ViewBag.ForPassengers = _context.ForPassengers.FirstOrDefault().FullName;
            return View("IndexLuggageView", await _context.AirportWarehouses.Include(t=>t.ForPassenger).ToListAsync());
        }

        [HttpGet]
        public IActionResult CreateLuggage()
        {
            ViewBag.ForPassengers = new SelectList(_context.ForPassengers, "Id", "FullName");
            return PartialView("CreateLuggagePartialView");
        }

        [HttpPost]
        public async Task<IActionResult> CreateLuggage(AirportWarehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(warehouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexLuggage));
            }

            return PartialView("CreateLuggagePartialView", warehouse);
        }

        public async Task<IActionResult> DetailsLuggage(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var luggage = await _context.AirportWarehouses
                                .Include(t=>t.ForPassenger)
                                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            if(luggage is null)
            {
                return NotFound();
            }

            return View("DetailsLuggageView",luggage);
        }

        [HttpGet]
        public async Task<IActionResult> EditLuggage(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var existingLuggage = await _context.AirportWarehouses.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if(existingLuggage is null)
            {
                return NotFound();
            }

            ViewData["ForPassengerId"] = new SelectList(_context.AirportWarehouses, "Id", "Id");
            return View("EditLuggageView", existingLuggage);
        }

        [HttpPost]
        public async Task<IActionResult> EditLuggage (AirportWarehouse edited, string id)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(edited);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(IndexLuggage));
            }

            return View("EditLuggageView", edited);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteLuggage(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var luggage = await _context.AirportWarehouses.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if(luggage is null)
            {
                return NotFound();
            }

            return View("DeleteLuggageView", luggage);
        }

        [HttpPost, ActionName("DeleteLuggage")]
        public async Task<IActionResult> DeleteLuggageConfirm(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var existedLuggage = await _context.AirportWarehouses.FirstOrDefaultAsync(x => x.Id.Equals(id));
            _context.Remove(existedLuggage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexLuggage));
        }
    }
}
