using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Controllers.CityAdministration
{
    public class RequestsConfirmationController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/CityAdministration/RequestsConfirmation/Index.cshtml");
        }
    }
}
