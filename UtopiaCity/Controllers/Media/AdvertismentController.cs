using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UtopiaCity.Data;
using UtopiaCity.Helpers;
using UtopiaCity.Models.Media;
using UtopiaCity.Services.Media;

namespace UtopiaCity.Controllers.Media
{
    public class AdvertismentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AdvertismentService _service;

        public AdvertismentController(AdvertismentService service, ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        // GET: Advertisment
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAdvertisments());
        }

        // GET: Advertisment/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisment = await _service.GetAdvertismentById(id);
            
            if (advertisment == null)
            {
                return NotFound();
            }

            return View(advertisment);
        }

        // GET: Advertisment/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees_, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users_, "Id", "Id");
            return View();
        }

        // POST: Advertisment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Advertisment advertisment)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAdvertisment(advertisment);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees_, "Id", "Id", advertisment.EmployeeId);
            ViewData["UserId"] = new SelectList(_context.Users_, "Id", "Id", advertisment.UserId);
            return View(advertisment);
        }

        // GET: Advertisment/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisment = await _service.GetAdvertismentById(id);
            if (advertisment == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees_, "Id", "Id", advertisment.EmployeeId);
            ViewData["UserId"] = new SelectList(_context.Users_, "Id", "Id", advertisment.UserId);
            return View(advertisment);
        }

        // POST: Advertisment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Advertisment advertisment)
        {
            if (id != advertisment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAdvertismentById(advertisment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertismentExists(advertisment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (AppException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["EmployeeId"] = new SelectList(_context.Employees_, "Id", "Id", advertisment.EmployeeId);
            ViewData["UserId"] = new SelectList(_context.Users_, "Id", "Id", advertisment.UserId);
            return View(advertisment);
        }

        // GET: Advertisment/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisment = await _service.GetAdvertismentById(id);
            return advertisment == null ? NotFound() : (IActionResult)View(advertisment);
        }

        // POST: Advertisment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                await _service.DeleteAdvertismentById(id);
                return RedirectToAction(nameof(Index));
            }
            catch (AppException)
            {
                throw;
            }
        }

        private bool AdvertismentExists(string id)
        {
            return _context.Advertisments.Any(e => e.Id == id);
        }
    }
}
