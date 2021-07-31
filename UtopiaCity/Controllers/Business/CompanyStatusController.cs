using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Business;
using UtopiaCity.Services.Business;

namespace UtopiaCity.Controllers.Business
{
    public class CompanyStatusController: Controller
    {
        private readonly CompanyStatusService _companyStatusService;

        public CompanyStatusController(CompanyStatusService companyStatusService)
        {
            _companyStatusService = companyStatusService;
        }

        public async Task<IActionResult> Index()
        {
            return View("Index", await _companyStatusService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyStatus status)
        {
            if (ModelState.IsValid)
            {
                await _companyStatusService.Create(status);
                return RedirectToAction(nameof(Index));
            }

            return View("Create", status);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var status = await _companyStatusService.GetById(id);
            if (status == null)
            {
                return NotFound();
            }

            return View("Edit", status);
        }

        [HttpPost]
        public async Task<IActionResult>Edit(string id, CompanyStatus status)
        {
            if (id != status.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _companyStatusService.Update(status);
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", status);
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var status = await _companyStatusService.GetById(id);
            if (status == null)
            {
                return NotFound();
            }

            return View("Delete", status);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var status = await _companyStatusService.GetById(id);
            if (status == null)
            {
                return NotFound();
            }

            await _companyStatusService.Delete(status);
            return RedirectToAction(nameof(Index));
        }
    }
}
