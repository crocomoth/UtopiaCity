using Microsoft.AspNetCore.Mvc;

namespace UtopiaCity.Controllers.Timeline
{
    public class OverrideBreadcrumbExampleController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
