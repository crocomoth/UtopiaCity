using Microsoft.AspNetCore.Mvc;

namespace UtopiaCity.Controllers.CityAdministration
{
    public class CityAdministrationHomeController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/CityAdministration/Index.cshtml");
        }
    }
}
