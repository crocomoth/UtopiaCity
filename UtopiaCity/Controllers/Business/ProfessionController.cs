using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Business;
using UtopiaCity.Services.Business;

namespace UtopiaCity.Controllers.Business
{
    public class ProfessionController: Controller
    {
        private readonly ProfessionAppService _professionAppService;

        public ProfessionController(ProfessionAppService professionAppService)
        {
            _professionAppService = professionAppService;
        }

        public async Task<IActionResult> Index()
        {
            return View("Index", await _professionAppService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Profession profession)
        {
            if (ModelState.IsValid)
            {
                await _professionAppService.Create(profession);
                return RedirectToAction(nameof(Index));
            }

            return View("Create", profession);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var profession = await _professionAppService.GetById(id);
            if (profession == null)
            {
                return NotFound();
            }

            return View("Edit", profession);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, Profession profession)
        {
            if (id != profession.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _professionAppService.Update(profession);
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", profession);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var profession = await _professionAppService.GetById(id);
            if (profession == null)
            {
                return NotFound();
            }

            return View("Delete", profession);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var profession = await _professionAppService.GetById(id);
            if (profession == null)
            {
                return NotFound();
            }

            await _professionAppService.Delete(profession);
            return RedirectToAction(nameof(Index));
        }
    }
}
