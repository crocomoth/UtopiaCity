using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Clinic;
using UtopiaCity.Services.Clinic;

namespace UtopiaCity.Controllers.Clinic
{
    public class ClinicReportController : Controller
    {
        private readonly ClinicReportService _clinicReportService;

        public ClinicReportController(ClinicReportService clinicReportService)
        {
            _clinicReportService = clinicReportService;
        }

        // view list of reports
        public async Task<IActionResult> Index()
        {
            return View("ClinicReportListView", await _clinicReportService.GetClinicReports());
        }

        // get specific item by id
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var report = await _clinicReportService.GetClinicReportById(id);
            if (report == null)
            {
                return NotFound();
            }

            return View("DetailsClinicReportView", report);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateClinicReportView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClinicReport newReport)
        {
            if (ModelState.IsValid)
            {
                await _clinicReportService.AddClinicReport(newReport);
                return RedirectToAction(nameof(Index));
            }

            return View("CreateClinicReportView", newReport);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var report = await _clinicReportService.GetClinicReportById(id);
            if (report == null)
            {
                return NotFound();
            }

            return View("EditClinicReportView", report);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ClinicReport edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _clinicReportService.UpdateClinicReport(edited);
                return RedirectToAction(nameof(Index));
            }

            return View("EditClinicReportView", edited);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var report = await _clinicReportService.GetClinicReportById(id);
            if (report == null)
            {
                return NotFound();
            }

            return View("DeleteClinicReportView", report);
        }

        [HttpPost, ActionName("DeleteClinicReportView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var report = await _clinicReportService.GetClinicReportById(id);
            if (report == null)
            {
                // TODO rewrite?
                return NotFound();
            }

            await _clinicReportService.DeleteClinicReport(report);
            return RedirectToAction(nameof(Index));
        }


    }
}
