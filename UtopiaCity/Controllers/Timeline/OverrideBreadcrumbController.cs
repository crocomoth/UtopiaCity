using Microsoft.AspNetCore.Mvc;

namespace UtopiaCity.Controllers.Timeline
{
    public class OverrideBreadcrumbController : BaseController
    {
        public IActionResult Index()
        {
            return View("BreadcrumsView");
        }
    }
}
