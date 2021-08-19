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
    public class ResumeController: Controller
    {
        private readonly ResumeAppService _resumeAppService;
        public ResumeController(ResumeAppService resumeAppService)
        {
            _resumeAppService = resumeAppService;
        }

        public async Task<IActionResult> Index()
        {
            return View("Index", await _resumeAppService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["ResidentAccountId"] = new SelectList(await _resumeAppService.GetAllResidentAccount(), "Id", "FIO");
            ViewData["ProfessionId"] = new SelectList(await _resumeAppService.GetAllProfession(), "Id", "Name");
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Resume resume)
        {
            if (ModelState.IsValid)
            {
                await _resumeAppService.Create(resume);
                return RedirectToAction(nameof(Index));
            }

            return View("Create", resume);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var resume = await _resumeAppService.GetById(id);
            ViewData["ResidentAccountId"] = new SelectList(await _resumeAppService.GetAllResidentAccount(), "Id", "FIO", resume.ResidentAccountId);
            ViewData["ProfessionId"] = new SelectList(await _resumeAppService.GetAllProfession(), "Id", "Name", resume.ProfessionId);
            if (resume == null)
            {
                return NotFound();
            }

            return View("Edit", resume);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, Resume resume)
        {
            if (id != resume.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _resumeAppService.Update(resume);
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", resume);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var resume = await _resumeAppService.GetById(id);
            ViewData["ResidentAccountId"] = new SelectList(await _resumeAppService.GetAllResidentAccount(), "Id", "FIO", resume.ResidentAccountId);
            ViewData["ProfessionId"] = new SelectList(await _resumeAppService.GetAllProfession(), "Id", "Name", resume.ProfessionId);
            if (resume == null)
            {
                return NotFound();
            }

            return View("Delete", resume);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var resume = await _resumeAppService.GetById(id);
            if (resume == null)
            {
                return NotFound();
            }

            await _resumeAppService.Delete(resume);
            return RedirectToAction(nameof(Index));
        }
    }
}
