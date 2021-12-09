using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UtopiaCity.Data;
using UtopiaCity.Models.Media;
using UtopiaCity.Services.Media;

namespace UtopiaCity.Controllers.Media
{
    //[Authorize(Roles = "Admin, Author")]
    public class DataCaptureController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DataCaptureService _service;
        public DataCaptureController(ApplicationDbContext context, DataCaptureService service)
        {
            _context = context;
            _service = service;
        }

        // GET: DataCapture
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllDataCaptures());
        }

        // GET: DataCapture/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataCapture = await _service.GetDataCaptureById(id);
            
            if (dataCapture == null)
            {
                return NotFound();
            }

            return View(dataCapture);
        }

        // GET: DataCapture/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees_, "Id", "Id");
            return View();
        }

        // POST: DataCapture/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DataCapture dataCapture)
        {
            if (ModelState.IsValid)
            {
                await _service.AddDataCapture(dataCapture);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees_, "Id", "Id", dataCapture.EmployeeId);
            return View(dataCapture);
        }

        // GET: DataCapture/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataCapture = await _service.GetDataCaptureById(id);
            if (dataCapture == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees_, "Id", "Id", dataCapture.EmployeeId);
            return View(dataCapture);
        }

        // POST: DataCapture/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, DataCapture dataCapture)
        {
            if (id != dataCapture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateDataCaptureById(dataCapture);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataCaptureExists(dataCapture.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees_, "Id", "Id", dataCapture.EmployeeId);
            return View(dataCapture);
        }

        // GET: DataCapture/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataCapture = await _service.GetDataCaptureById(id);
            if (dataCapture == null)
            {
                return NotFound();
            }

            return View(dataCapture);
        }

        // POST: DataCapture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _service.DeleteDataCaptureById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DataCaptureExists(string id)
        {
            return _context.DataCaptures.Any(e => e.Id == id);
        }
    }
}
