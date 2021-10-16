using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess;
using UtopiaCity.Services.FireSystem;
using UtopiaCity.ViewModels.FireSystem;

namespace UtopiaCity.Controllers.FireSystem
{
    public class FireSafetyDepartmentController : Controller
    {
        private readonly FireSafetyDepartmentService _fireSafetyDepartmentService;
        private readonly IMapper _mapper;

        public FireSafetyDepartmentController(FireSafetyDepartmentService fireSafetyDepartmentService, IMapper mapper)
        {
            _fireSafetyDepartmentService = fireSafetyDepartmentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<FireSafetyDepartment> departments = await _fireSafetyDepartmentService.GetDepartments();
            List<DepartmentViewModel> departmentViewModels = new List<DepartmentViewModel>();
            foreach(FireSafetyDepartment department in departments)
            {
                departmentViewModels.Add(_mapper.Map<DepartmentViewModel>(department));
            }

            return View("FireSafetyDepartmentListView", departmentViewModels);
        }

        public async Task<IActionResult> Details(string id)
        {
            FireSafetyDepartment department = await _fireSafetyDepartmentService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }

            DepartmentViewModel departmentViewModel = _mapper.Map<DepartmentViewModel>(department);

            return View("FireSafetyDepartmentDetailsView", departmentViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        { 
            return View("FireSafetyDepartmentCreateView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentViewModel departmentViewModel)
        {
            if (departmentViewModel == null)
            {
                return NotFound();
            }

            FireSafetyDepartment department = _mapper.Map<FireSafetyDepartment>(departmentViewModel);
            await _fireSafetyDepartmentService.CreateDepartment(department);
            //return View("FireSafetyDepartmentCreateView", department);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            FireSafetyDepartment department = await _fireSafetyDepartmentService.GetDepartmentById(id);
            if(department == null)
            {
                return NotFound();
            }

            DepartmentViewModel departmentViewModel = _mapper.Map<DepartmentViewModel>(department);    
            return View("FireSafetyDepartmentEditView", departmentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, DepartmentViewModel departmentViewModel)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            if(departmentViewModel == null)
            {
                return NotFound();
            }
            if (id != departmentViewModel.Id)
            {
                return NotFound();
            }

            FireSafetyDepartment department = _mapper.Map<FireSafetyDepartment>(departmentViewModel);
            await _fireSafetyDepartmentService.UpdateDepartment(department);
            //return View("FireSafetyDepartmentEditView", department);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            FireSafetyDepartment department = await _fireSafetyDepartmentService.GetDepartmentById(id);
            if(department == null)
            {
                return NotFound();
            }

            DepartmentViewModel departmentViewModel = _mapper.Map<DepartmentViewModel>(department);

            return View("FireSafetyDepartmentDeleteView", departmentViewModel);
        }

        [HttpPost, ActionName("FireSafetyDepartmentDeleteView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            FireSafetyDepartment department = await _fireSafetyDepartmentService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }

            await _fireSafetyDepartmentService.DeleteDepartment(department);
            return RedirectToAction(nameof(Index));
        }
    }
}
