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
    public class EmployeeController: Controller
    {
        private readonly EmployeeAppService _employeeAppService;
        public EmployeeController(EmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        public async Task<IActionResult> Index()
        {
            return View("Index", await _employeeAppService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["ProfessionId"] = new SelectList(await _employeeAppService.GetAllProfession(), "Id", "Name");
            ViewData["CompanyId"] = new SelectList(await _employeeAppService.GetAllCompany(), "Id", "Name");
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeAppService.Create(employee);
                return RedirectToAction(nameof(Index));
            }

            return View("Create", employee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var employee = await _employeeAppService.GetById(id);
            ViewData["ProfessionId"] = new SelectList(await _employeeAppService.GetAllProfession(), "Id", "Name", employee.ProfessionId);
            ViewData["CompanyId"] = new SelectList(await _employeeAppService.GetAllCompany(), "Id", "Name", employee.CompanyId);
            if (employee == null)
            {
                return NotFound();
            }

            return View("Edit", employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _employeeAppService.Update(employee);
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", employee);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var employee = await _employeeAppService.GetById(id);
            ViewData["ProfessionId"] = new SelectList(await _employeeAppService.GetAllProfession(), "Id", "Name", employee.ProfessionId);
            ViewData["CompanyId"] = new SelectList(await _employeeAppService.GetAllCompany(), "Id", "Name", employee.CompanyId);
            if (employee == null)
            {
                return NotFound();
            }

            return View("Delete", employee);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _employeeAppService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            await _employeeAppService.Delete(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
