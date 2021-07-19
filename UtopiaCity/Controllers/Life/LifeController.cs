using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
