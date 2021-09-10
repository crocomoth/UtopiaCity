using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;
using UtopiaCity.Services.FireSystem;

namespace UtopiaCity.Controllers.FireSystem
{
    public class TransportManagementController : Controller
    {
        private readonly TransportManagementService _transportManagementService;

        public TransportManagementController(TransportManagementService transportManagementService)
        {
            _transportManagementService = transportManagementService;
        }

        public async Task<IActionResult> Index()
        {
            return View("TransportManagentListView", await _transportManagementService.GetTrasports());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var transport = await _transportManagementService.GetTrasportById(id);
            if (transport == null)
            {
                return NotFound();
            }

            return View("DetailsTransportManagementView", transport);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["DepartmentId"] = new SelectList(await _transportManagementService.GetDepartments(), "Id", "Name"));
            return View("CreateTransportManagementView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransportManagement newTransport)
        {
            if (ModelState.IsValid)
            {
                await _transportManagementService.AddTransport(newTransport);
                return RedirectToAction(nameof(Index));
            }

            return View("CreateTransportManagementView", newTransport);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var transport = await _transportManagementService.GetTrasportById(id);
            ViewData["DepartmentId"] = new SelectList(await _transportManagementService.GetDepartments(), "Id", "Name");)
            if (transport == null)
            {
                return NotFound();
            }

            return View("EditTransportManagementView", transport);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, TransportManagement edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _transportManagementService.UpdateTrasnport(edited);
                return RedirectToAction(nameof(Index));
            }

            return View("EditTransportManagementView", edited);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var transport = await _transportManagementService.GetTrasportById(id);
            ViewData["DepartmentId"] = new SelectList(await _transportManagementService.GetDepartments(), "Id", "Name");)
            if (transport == null)
            {
                return NotFound();
            }

            return View("DeleteTransportManagementView", transport);
        }

        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var transport = await _transportManagementService.GetTrasportById(id);
            if (transport == null)
            {
                return NotFound();
            }

            await _transportManagementService.DeleteTransport(transport);
            return RedirectToAction(nameof(Index));
        }
    }
}
