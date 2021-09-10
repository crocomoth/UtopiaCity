using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.FireSystem;
using UtopiaCity.Services.FireSystem;

namespace UtopiaCity.Controllers.FireSystem
{
    public class DepartmentStatusController : Controller
    {
        private readonly DepartmentStatusService _departmentStatusService;

        public DepartmentStatusController(DepartmentStatusService departmentStatusService)
        {
            _departmentStatusService = departmentStatusService;
        }

        public async Task<IActionResult> Index()
        {
            return View("DepartmentStatusListView", await _departmentStatusService.GetDepartments());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateDepartmentStatusView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentStatus status)
        {
            if (ModelState.IsValid)
            {
                await _departmentStatusService.AddDepartmentStatus(status);
                return RedirectToAction(nameof(Index));
            }

            return View("CreateDepartmentStatusView", status);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var status = await _departmentStatusService.GetDepartmentById(id);
            if(status == null)
            {
                return NotFound();
            }

            return View("EditDepartmentStatusView", status);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, DepartmentStatus status)
        {
            if(id != status.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _departmentStatusService.UpdateDepartmentStatus(status);
                return RedirectToAction(nameof(Index));
            }

            return View("EditDepartmentStatusView", status);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var status = await _departmentStatusService.GetDepartmentById(id);
            if(status == null)
            {
                return NotFound();
            }

            await _departmentStatusService.DeleteDepartmentStatus(status);
            return View("DeleteDepartmentStatusView", status);
        }

        [HttpPost] // ActionName("Delete")
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var status = await _departmentStatusService.GetDepartmentById(id);
            if(status == null)
            {
                return NotFound();
            }

            await _departmentStatusService.DeleteDepartmentStatus(status);
            return RedirectToAction(nameof(Index));
        }
    }
}
