using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Business;
using UtopiaCity.Services.Business;

namespace UtopiaCity.Controllers.Business
{
    public class VacancyController: Controller
    {
        private readonly VacancyAppService _vacancyAppService;

        public VacancyController(VacancyAppService vacancyAppService)
        {
            _vacancyAppService = vacancyAppService;
        }

        public async Task<IActionResult> Index()
        {
            return View("Index", await _vacancyAppService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["CompanyId"] = new SelectList(await _vacancyAppService.GetAllCompany(), "Id", "Name");
            ViewData["ProfessionId"] = new SelectList(await _vacancyAppService.GetAllProfession(), "Id", "Name");
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                await _vacancyAppService.Create(vacancy);
                return RedirectToAction(nameof(Index));
            }

            return View("Create", vacancy);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var vacancy = await _vacancyAppService.GetById(id);
            ViewData["CompanyId"] = new SelectList(await _vacancyAppService.GetAllCompany(), "Id", "Name", vacancy.CompanyId);
            ViewData["ProfessionId"] = new SelectList(await _vacancyAppService.GetAllProfession(), "Id", "Name", vacancy.ProfessionId);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View("Edit", vacancy);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, Vacancy vacancy)
        {
            if (id != vacancy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _vacancyAppService.Update(vacancy);
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", vacancy);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var vacancy = await _vacancyAppService.GetById(id);
            ViewData["CompanyId"] = new SelectList(await _vacancyAppService.GetAllCompany(), "Id", "Name", vacancy.CompanyId);
            ViewData["PorfessionId"] = new SelectList(await _vacancyAppService.GetAllProfession(), "Id", "Name", vacancy.ProfessionId);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View("Delete", vacancy);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vacancy = await _vacancyAppService.GetById(id);
            if (vacancy == null)
            {
                return NotFound();
            }

            await _vacancyAppService.Delete(vacancy);
            return RedirectToAction(nameof(Index));
        }
    }
}
