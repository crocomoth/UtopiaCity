using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.FireSystem;
using UtopiaCity.Services.FireSystem;

namespace UtopiaCity.Controllers.FireSystem
{
    public class FireSafetyCheckRequestController : Controller
    {
        private readonly FireSafetyCheckRequestService _fireSafetyCheckRequestService;
        private readonly FireSafetyCheckService _fireSafetyCheckService;
        public FireSafetyCheckRequestController(FireSafetyCheckRequestService fireSafetyCheckRequestService, FireSafetyCheckService fireSafetyCheckService)
        {
            _fireSafetyCheckRequestService = fireSafetyCheckRequestService;
            _fireSafetyCheckService = fireSafetyCheckService;
        }

        public async Task<IActionResult> Index()
        {
            return View("FireSafetyCheckRequestListView", await _fireSafetyCheckRequestService.GetFireSafetyCheckRequests());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var check = await _fireSafetyCheckRequestService.GetFireSafetyCheckRequestById(id);
            if (check == null)
            {
                return NotFound();
            }

            return View("DetailsFireSafetyCheckRequestView", check);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateFireSafetyCheckRequestView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(FireSafetyCheckRequest check)
        {
            if (ModelState.IsValid)
            {
                var request = await _fireSafetyCheckRequestService.AddFireSafetyCheckRequest(check);
                var canCheckEmployee = await _fireSafetyCheckRequestService.GetCanCheckEmployee();
                var fireSafetyCheck = new FireSafetyCheck
                {
                    Address = request.Address,
                    ObjectName = request.ObjectName,
                    FireSafetyDocuments = true,
                    FireFightingEquipment = true,
                    Journals = true,
                    FireSafetySigns = true,
                    EscapeRoutes = true,
                    SmokingAreas = true,
                    EmployeeId = canCheckEmployee.Id,
                    Employee = canCheckEmployee
                };
                var result = await new FireSafetyCheckController(_fireSafetyCheckService, null).Create(fireSafetyCheck);
                return RedirectToAction(nameof(Index));
            }

            return View("CreateFireSafetyCheckRequestView", check);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, FireSafetyCheckRequest check)
        {
            if (id != check.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _fireSafetyCheckRequestService.UpdadeFireSafetyCheckRequest(check);
                return RedirectToAction(nameof(Index));
            }

            return View("EditFireSafetyCheckRequestView", check);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var check = await _fireSafetyCheckRequestService.GetFireSafetyCheckRequestById(id);
            if (check == null)
            {
                return NotFound();
            }

            return View("DeleteFireSafetyCheckRequestView", check);
        }

        [HttpPost, ActionName("DeleteFireSafetyCheckRequestView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var check = await _fireSafetyCheckRequestService.GetFireSafetyCheckRequestById(id);
            if (check == null)
            {
                return NotFound();
            }

            await _fireSafetyCheckRequestService.DeleteFireSafetyCheckRequest(check);
            return RedirectToAction(nameof(Index));
        }
    }
}
