using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.FireSystem;
using UtopiaCity.Services.FireSystem;

namespace UtopiaCity.Controllers.FireSystem
{
    public class FireSafetyCheckController : Controller
    {
        private readonly FireSafetyCheckService _fireSafetyCheckService;
        private readonly EmployeeManagementService _employeeManagementService;

        public FireSafetyCheckController(FireSafetyCheckService fireSafetyCheckService, EmployeeManagementService employeeManagementService)
        {
            _fireSafetyCheckService = fireSafetyCheckService;
            _employeeManagementService = employeeManagementService;
        }
        //public FireSafetyCheckController(FireSafetyCheckService fireSafetyCheckService)
        //{
        //    _fireSafetyCheckService = fireSafetyCheckService;
        //}

        public async Task<IActionResult> Index()
        {
            return View("FireSafetyCheckListView", await _fireSafetyCheckService.GetFireSafetyChecks());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["EmployeeId"] = new SelectList(await _fireSafetyCheckService.GetEmployees(), "Id", "FullName");
            return View("CreateFireSafetyCheckView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(FireSafetyCheck check)
        {
            if (ModelState.IsValid)
            {
                await _fireSafetyCheckService.AddFireSafetyCheck(check);
                return RedirectToAction(nameof(Index));
            }

            return View("CreateFireSafetyCheckView", check);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var check = await _fireSafetyCheckService.GetFireSafetyCheckById(id);
            if (check == null)
            {
                return NotFound();
            }

            return View("DetailsFireSafetyCheckView", check);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var check = await _fireSafetyCheckService.GetFireSafetyCheckById(id);
            if (check == null)
            {
                return NotFound();
            }

            return View("EditFireSafetyCheckView", check);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, FireSafetyCheck check)
        {
            if(id == null)
            {
                return NotFound();
            }
            else if(check == null)
            {
                return NotFound();
            }

            await _fireSafetyCheckService.UpdadeFireSafetyCheck(check);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var check = await _fireSafetyCheckService.GetFireSafetyCheckById(id);
            ViewData["EmployeeId"] = new SelectList(await _fireSafetyCheckService.GetEmployees(), "Id", "FullName");
            if (check == null)
            {
                return NotFound();
            }

            return View("DeleteFireSafetyCheckView", check);
        }

        [HttpPost, ActionName("DeleteFireSafetyCheckView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var check = await _fireSafetyCheckService.GetFireSafetyCheckById(id);
            if (check == null)
            {
                return NotFound();
            }

            await _fireSafetyCheckService.DeleteFireSafetyCheck(check);
            return RedirectToAction(nameof(Index));
        }
    }
}
