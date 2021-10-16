using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.FireSystem;
using UtopiaCity.Services.FireSystem;

namespace UtopiaCity.Controllers.FireSystem
{
    public class DepatureToThePlaceController : Controller
    {
        private readonly DepatureToThePlaceService _depatureToThePlace;
        private readonly FireSafetyDepartmentService _fireSafetyDepartmentService;
        public DepatureToThePlaceController(DepatureToThePlaceService depatureToThePlace, FireSafetyDepartmentService fireSafetyDepartmentService)
        {
            _depatureToThePlace = depatureToThePlace;
            _fireSafetyDepartmentService = fireSafetyDepartmentService;
        }

        public async Task<IActionResult> Index()
        {
            return View("DepatureToThePlaceListView", await _depatureToThePlace.GetDepatures());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var depature = await _depatureToThePlace.GetDepatureById(id);
            if (depature == null)
            {
                return NotFound();
            }

            return View("DepatureToThePlaceDetailsView", depature);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.DepartmentsName = await _fireSafetyDepartmentService.GetDepartmentsNames();
            return View("CreateDepatureToThePlaceView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartureToThePlaceOfFire depature)
        {
            if (ModelState.IsValid)
            {
                await _depatureToThePlace.AddDepature(depature);
                return RedirectToAction(nameof(Index));
            }

            return View("CreateDepatureToThePlaceView", depature);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var depature = await _depatureToThePlace.GetDepatureById(id);
            ViewBag.DepartmentsName = await _fireSafetyDepartmentService.GetDepartmentsNames();
            if (depature == null)
            {
                return NotFound();
            }

            return View("EditDepatureToThePlaceView", depature);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, DepartureToThePlaceOfFire depature)
        {
            if (id != depature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _depatureToThePlace.UpdateDepature(depature);
                return RedirectToAction(nameof(Index));
            }

            return View("EditDepatureToThePlaceView", depature);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var departure = await _depatureToThePlace.GetDepatureById(id);
            ViewBag.DepartmentsName = await _fireSafetyDepartmentService.GetDepartmentsNames();
            if (departure == null)
            {
                return NotFound();
            }

            return View("DeleteDepatureToThePlaceView", departure);
        }

        [HttpPost, ActionName("DeleteDepatureToThePlaceView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var depature = await _depatureToThePlace.GetDepatureById(id);
            if (depature == null)
            {
                return NotFound();
            }

            await _depatureToThePlace.DeleteDepature(depature);
            return RedirectToAction(nameof(Index));
        }
    }
}
