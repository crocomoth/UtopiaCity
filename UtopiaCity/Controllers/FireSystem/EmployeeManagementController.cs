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
    public class EmployeeManagementController : Controller
    {
        private readonly EmployeeManagementService _employeeManagementService;
        private readonly FireSafetyDepartmentService _fireSafetyDepartmentService;
        private readonly PositionService _positionService;
        private readonly IMapper _mapper;

        public EmployeeManagementController(EmployeeManagementService employeeManagementService, FireSafetyDepartmentService fireSafetyDepartmentService, PositionService position, IMapper mapper)
        {
            _employeeManagementService = employeeManagementService;
            _fireSafetyDepartmentService = fireSafetyDepartmentService;
            _positionService = position;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<EmployeeManagement> employees = await _employeeManagementService.GetEmployees();
            List<EmployeeManagementViewModel> employeesViewModel = new List<EmployeeManagementViewModel>();
            foreach(var employee in employees)
            {
                employeesViewModel.Add(_mapper.Map<EmployeeManagementViewModel>(employee));
            }
            
            return View("EmployeeManagementListView", employeesViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.DepartmentsName = await _fireSafetyDepartmentService.GetDepartmentsNames();
            ViewBag.PositionsName = await _positionService.GetPositionsNames();
            return View("CreateEmployeeManagementView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeManagementViewModel employeeViewModel)
        { 
            if(employeeViewModel == null)
            {
                return NotFound();
            }

            string departmentId = await _fireSafetyDepartmentService.GetDepartmentIdByName(employeeViewModel.DepartmentName);
            string positionId = await _positionService.GetPositionIdByName(employeeViewModel.EmployeePosition);
            if (departmentId == null || positionId == null)
            {
                return NotFound();
            }

            employeeViewModel.DepartmentId = departmentId;
            employeeViewModel.Positionid = positionId;
            EmployeeManagement employee = _mapper.Map<EmployeeManagement>(employeeViewModel);
            await _employeeManagementService.AddEmployee(employee);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            EmployeeManagement employee = await _employeeManagementService.GetEmployeeByIdWithDepartmentAndPosition(id);
            if (employee == null)
            {
                return NotFound();
            }

            EmployeeManagementViewModel employeeViewModel = _mapper.Map<EmployeeManagementViewModel>(employee);

            return View("DetailsEmployeeManagementView", employeeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            EmployeeManagement employee = await _employeeManagementService.GetEmployeeByIdWithDepartmentAndPosition(id);
            if(employee == null)
            {
                return NotFound();
            }

            EmployeeManagementViewModel employeeViewModel = _mapper.Map<EmployeeManagementViewModel>(employee);
            ViewBag.DepartmentsNames = await _fireSafetyDepartmentService.GetDepartmentsNames();
            ViewBag.PositionsName = await _positionService.GetPositionsNames();

            return View("EditEmployeeManagementView", employeeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EmployeeManagementViewModel employeeViewModel)
        {
            if (id == null)
            {
                return NotFound();
            }
            else if (employeeViewModel == null)
            {
                return NotFound();
            }

            string departmentId = await _fireSafetyDepartmentService.GetDepartmentIdByName(employeeViewModel.DepartmentName);
            string positionId = await _positionService.GetPositionIdByName(employeeViewModel.EmployeePosition);
            if (departmentId == null || positionId == null)
            {
                return NotFound();
            }

            employeeViewModel.DepartmentId = departmentId;
            employeeViewModel.Positionid = positionId;
            EmployeeManagement employee = _mapper.Map<EmployeeManagement>(employeeViewModel);
            await _employeeManagementService.UpdateEmployee(employee);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            EmployeeManagement employee = await _employeeManagementService.GetEmployeeByIdWithDepartmentAndPosition(id);
            if(employee == null)
            {
                return NotFound();
            }

            EmployeeManagementViewModel employeeViewModel = _mapper.Map<EmployeeManagementViewModel>(employee);

            return View("DeleteEmployeeManagementView", employeeViewModel);
        }

        [HttpPost, ActionName("DeleteEmployeeManagementView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if(id == null)
            {
                return NotFound();
            }

            EmployeeManagement employee = await _employeeManagementService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            await _employeeManagementService.DeleteEmployee(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
