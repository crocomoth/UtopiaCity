using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Airport;
using UtopiaCity.Services.Airport;

namespace UtopiaCity.Controllers.Airport
{
    public class WeatherReportController:Controller
    {
        private readonly WeatherReportService _weatherReportService;

        public WeatherReportController(WeatherReportService reportService)
        {
            _weatherReportService = reportService;
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
            return View();
        }

        [HttpPost]
        public IActionResult Create(WeatherReport weatherReport)
        {
            var dateTimeReport = _weatherReportService.GetReportDateTimeValidation(weatherReport);
            if (dateTimeReport is null)
            {
                return View("DateTimeError");
            }

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
    }
}
