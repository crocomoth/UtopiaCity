using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Clinic;
using UtopiaCity.Services.Clinic;

namespace UtopiaCity.Controllers.Clinic
{
    public class ClinicVisitController : Controller
    {
        private readonly ClinicVisitService _clinicVisitService;

        public ClinicVisitController(ClinicVisitService clinicVisitService)
        {
            _clinicVisitService = clinicVisitService;
        }

        // view list of reports
        public async Task<IActionResult> Index()
        {
            return View("ClinicVisitListView", await _clinicVisitService.GetClinicVisits());
        }

        // get specific item by id
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var visit = await _clinicVisitService.GetClinicVisitById(id);
            if (visit == null)
            {
                return NotFound();
            }

            return View("DetailsClinicVisitView", visit);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateClinicVisitView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClinicVisit newVisit)
        {
            if (ModelState.IsValid)
            {
                await _clinicVisitService.AddClinicVisit(newVisit);
                return RedirectToAction(nameof(Index));
            }

            return View("CreateClinicVisitView", newVisit);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var visit = await _clinicVisitService.GetClinicVisitById(id);
            if (visit == null)
            {
                return NotFound();
            }

            return View("EditClinicVisitView", visit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ClinicVisit edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _clinicVisitService.UpdateClinicVisit(edited);
                return RedirectToAction(nameof(Index));
            }

            return View("EditClinicVisitView", edited);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var visit = await _clinicVisitService.GetClinicVisitById(id);
            if (visit == null)
            {
                return NotFound();
            }

            return View("DeleteClinicVisitView", visit);
        }

        [HttpPost, ActionName("DeleteClinicVisitView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var visit = await _clinicVisitService.GetClinicVisitById(id);
            if (visit == null)
            {
                // TODO rewrite?
                return NotFound();
            }

            await _clinicVisitService.DeleteClinicVisit(visit);
            return RedirectToAction(nameof(Index));
        }


    }
}
