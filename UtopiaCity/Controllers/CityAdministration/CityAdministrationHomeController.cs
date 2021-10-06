using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UtopiaCity.Controllers.CityAdministration
{
    [Authorize]
    public class CityAdministrationHomeController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/CityAdministration/Index.cshtml");
        }
    }
}
