using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Airport;
using UtopiaCity.Services.Airport;
using UtopiaCity.Services.Timeline;

namespace UtopiaCity.Controllers.Airport
{
    public class WeatherReportController:Controller
    {
        private readonly WeatherReportService _weatherReportService;
        private readonly PermitedConditonsService _permissionService;

        public WeatherReportController(WeatherReportService reportService,PermitedConditonsService service)
        {
            _weatherReportService = reportService;
            _permissionService = service;
        }

        public IActionResult Index()
        {
            return View(_weatherReportService.GetWeatherReportsList());
        }

        public IActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var weather = _weatherReportService.GetWeatherReportById(id);
            if(weather is null)
            {
                return NotFound();
            }

            return View(weather);
        }

        [HttpGet]
        public IActionResult Create()
        {
           SelectList reports = new SelectList(_permissionService.GetList().GetAwaiter().GetResult(), "Id", "PermissionDate");
            ViewBag.Reports = reports;
            return View();
        }

        [HttpPost]
        public IActionResult Create(WeatherReport weatherReport)
        {
            if (ModelState.IsValid)
            {
                
                _weatherReportService.CreateWeatherReport(weatherReport);
                
                return RedirectToAction(nameof(Index));
            }

            return View(weatherReport);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var weather = _weatherReportService.GetWeatherReportById(id);
            if(weather is null)
            {
                return NotFound();
            }

            return View(weather);
        }

        [HttpPost]
        public IActionResult Edit(string id,WeatherReport edited)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _weatherReportService.UpdateWeatherReport(edited);
                return RedirectToAction(nameof(Index));
            }

            return View(edited);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                NotFound();
            }

            var weather = _weatherReportService.GetWeatherReportById(id);
            if (weather is null)
            {
                NotFound();
            }

            return View(weather);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var weather =_weatherReportService.GetWeatherReportById(id);
            if (weather is null)
            {
                NotFound();
            }

            _weatherReportService.DeleteWeatherReport(weather);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Dispatcher(string id)
        {           
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var report = _weatherReportService.GetWeatherReportById(id);
            if(report is null)
            {
                return NotFound();
            }

            return View("DispatcherCheckView", report);
        }

        // method Dispatcher to check weather conditions for flight by using PermitedModel
        [HttpPost,ActionName("Dispatcher")]
        public IActionResult DispatcherCheck(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var existingReport = _weatherReportService.GetWeatherReportById(id);
            if (ModelState.IsValid)
            {
                var list= _permissionService.GetList().GetAwaiter().GetResult();
                var permitedDateTime = list.FirstOrDefault().PermissionDate;
                if(_weatherReportService.GetPermitedWeatherReport(permitedDateTime))
                {
                    existingReport.FlightWeather = "Status:allowed";
                }
                else
                {
                    existingReport.FlightWeather = "Status:rejected";
                }
                _weatherReportService.UpdateWeatherReport(existingReport);
                return RedirectToAction(nameof(Index));
            }
            return View("DispatcherCheckView", existingReport);
        }
    }
}
