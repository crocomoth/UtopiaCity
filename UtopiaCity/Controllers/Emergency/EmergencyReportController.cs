using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Emergency;

namespace UtopiaCity.Controllers.Emergency
{
    public class EmergencyReportController : Controller
    {
        private ApplicationDbContext _dbContext;

        public EmergencyReportController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // view list of reports
        public async Task<IActionResult> Index()
        {
            return View("EmergencyReportListView", await _dbContext.EmergencyReport.ToListAsync());
        }

        // get specific item by id
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var report = await _dbContext.EmergencyReport.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (report == null)
            {
                NotFound();
            }

            return View(report);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmergencyReport newReport)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(newReport);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(newReport);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var report = await _dbContext.EmergencyReport.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EmergencyReport edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dbContext.Update(edited);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(edited);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var report = await _dbContext.EmergencyReport.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var report = await _dbContext.EmergencyReport.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (report == null)
            {
                // TODO rewrite?
                return NotFound();
            }

            _dbContext.Remove(report);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
