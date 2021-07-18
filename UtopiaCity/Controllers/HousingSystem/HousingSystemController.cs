using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Controllers.HousingSystem
{
    public class HousingSystemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
