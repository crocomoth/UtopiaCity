using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Life;
using UtopiaCity.Services.Life;

namespace UtopiaCity.Controllers.Life
{
    public class LifeController : Controller
    {
        private readonly LifeService _service;
        public LifeController(LifeService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Event e)
        {
            if (ModelState.IsValid)
            {
                _service.Add(e);
                return RedirectToAction(nameof(Index));
            }

            return View("Create", e);
        }
    }
}
