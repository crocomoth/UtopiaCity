using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Business;
using UtopiaCity.Services.Business;
using UtopiaCity.Utils;

namespace UtopiaCity.Controllers.Business
{
    public class CompanyController: Controller
    {
        private readonly CompanyAppService _companyAppService;

        public CompanyController(CompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
        }

        public async Task<IActionResult> Index()
        {
            return View("Index", await _companyAppService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["BankId"] = new SelectList(await _companyAppService.GetAllBank(), "Id", "Name");
            ViewData["CompanyStatusId"] = new SelectList(await _companyAppService.GetAllCompanyStatus(), "Id", "Name");
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {
            if (ModelState.IsValid)
            {
                company.IIK = "KZ" + RandomUtil.GenerateRandomString(18);
                company.BIN = RandomUtil.GenerateRandomString(12);
                await _companyAppService.Create(company);
                return RedirectToAction(nameof(Index));
            }

            return View("Create", company);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var company = await _companyAppService.GetById(id);
            ViewData["BankId"] = new SelectList(await _companyAppService.GetAllBank(), "Id", "Name", company.BankId);
            ViewData["CompanyStatusId"] = new SelectList(await _companyAppService.GetAllCompanyStatus(), "Id", "Name", company.CompanyStatusId);
            if (company == null)
            {
                return NotFound();
            }

            return View("Edit", company);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _companyAppService.Update(company);
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", company);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var company = await _companyAppService.GetById(id);
            ViewData["BankId"] = new SelectList(await _companyAppService.GetAllBank(), "Id", "Name", company.BankId);
            ViewData["CompanyStatusId"] = new SelectList(await _companyAppService.GetAllCompanyStatus(), "Id", "Name", company.CompanyStatusId);
            if (company == null)
            {
                return NotFound();
            }

            return View("Delete", company);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var company = await _companyAppService.GetById(id);
            if (company == null)
            {
                return NotFound();
            }

            await _companyAppService.Delete(company);
            return RedirectToAction(nameof(Index));
        }
    }
}
