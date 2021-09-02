using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;
using UtopiaCity.Services.FireSystem;

namespace UtopiaCity.Controllers.FireSystem
{

    public class EmployeeManagementController : Controller
    {
        private readonly EmployeeManagementService _employeeManagementService;

        public EmployeeManagementController(EmployeeManagementService employeeManagementService)
        {
            _employeeManagementService = employeeManagementService;
        }

        public async Task<IActionResult> Index()
        {
            return View("EmployeeManagementListView", await _employeeManagementService.GetEmployees());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var employee = await _employeeManagementService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View("DetailsEmployeeManagementView", employee);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateEmployeeManagementView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeManagement newEmployee)
        {
            if (ModelState.IsValid)
            {
                await _employeeManagementService.AddEmployee(newEmployee);
                return RedirectToAction(nameof(Index));
            }

            return View("CreateEmployeeManagementView", newEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var employee = await _employeeManagementService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View("EditEmployeeManagementView", employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EmployeeManagement edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _employeeManagementService.UpdateEmployee(edited);
                return RedirectToAction(nameof(Index));
            }

            return View("EditEmployeeManagementView", edited);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var employee = await _employeeManagementService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View("DeleteEmployeeManagementView", employee);
        }

        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _employeeManagementService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            await _employeeManagementService.DeleteEmployee(employee);
            return RedirectToAction(nameof(Index));
        }

    }
}
