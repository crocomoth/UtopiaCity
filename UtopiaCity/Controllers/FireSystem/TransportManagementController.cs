using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;
using UtopiaCity.Services.FireSystem;
using UtopiaCity.ViewModels.FireSystem;

namespace UtopiaCity.Controllers.FireSystem
{
    public class TransportManagementController : Controller
    {
        private readonly TransportManagementService _transportManagementService;
        private readonly IMapper _mapper;
        private readonly FireSafetyDepartmentService _fireSafetyDepartmentService;
        public TransportManagementController(TransportManagementService transportManagementService, FireSafetyDepartmentService fireSafetyDepartmentService, IMapper mapper)
        {
            _transportManagementService = transportManagementService;
            _fireSafetyDepartmentService = fireSafetyDepartmentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<TransportManagement> transports = await _transportManagementService.GetTrasports();
            List<TransportManagementViewModel> transportsViewModels = new List<TransportManagementViewModel>();
            foreach(var transport in transports)
            {
                transportsViewModels.Add(_mapper.Map<TransportManagementViewModel>(transport));
            }
            return View("TransportManagentListView", transportsViewModels);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            TransportManagement transport = await _transportManagementService.GetTransportByIdWithDepartment(id);
            if (transport == null)
            {
                return NotFound();
            }
            TransportManagementViewModel transportViewModel = _mapper.Map<TransportManagementViewModel>(transport);
            

            return View("DetailsTransportManagementView", transportViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.DepartmentsName = await _fireSafetyDepartmentService.GetDepartmentsNames();
            return View("CreateTransportManagementView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransportManagementViewModel transportViewModel)
        {
            if(transportViewModel == null)
            {
                return NotFound();
            }

            string departmentId = await _fireSafetyDepartmentService.GetDepartmentIdByName(transportViewModel.DepartmentName);
            if (departmentId == null)
            {
                return NotFound();
            }

            transportViewModel.DepartmentId = departmentId;
            TransportManagement transport = _mapper.Map<TransportManagement>(transportViewModel);
            await _transportManagementService.AddTransport(transport);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            TransportManagement transport = await _transportManagementService.GetTransportByIdWithDepartment(id);
            if (transport == null)
            {
                return NotFound();
            }

            TransportManagementViewModel transportViewModel = _mapper.Map<TransportManagementViewModel>(transport);
            ViewBag.DepartmentsNames = await _fireSafetyDepartmentService.GetDepartmentsNames();

            return View("EditTransportManagementView", transportViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, TransportManagementViewModel transporViewModel)
        {
            if (id == null)
            {
                return NotFound();
            }
            else if(transporViewModel == null)
            {
                return NotFound();
            }

            string departmentId = await _fireSafetyDepartmentService.GetDepartmentIdByName(transporViewModel.DepartmentName);
            if (departmentId == null)
            {
                return NotFound();
            }

            transporViewModel.DepartmentId = departmentId;
            TransportManagement transport = _mapper.Map<TransportManagement>(transporViewModel);
            await _transportManagementService.UpdateTrasnport(transport);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            TransportManagement transport = await _transportManagementService.GetTransportByIdWithDepartment(id);
            if (transport == null)
            {
                return NotFound();
            }

            TransportManagementViewModel transportViewModel = _mapper.Map<TransportManagementViewModel>(transport);

            return View("DeleteTransportManagementView", transportViewModel);
        }

        [HttpPost, ActionName("DeleteTransportManagementView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TransportManagement transport = await _transportManagementService.GetTrasportById(id);
            if (transport == null)
            {
                return NotFound();
            }

            await _transportManagementService.DeleteTransport(transport);
            return RedirectToAction(nameof(Index));
        }
    }
}
