using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Utils.Attributes;

namespace UtopiaCity.Controllers.Timeline
{
    [BreadcrumbActionFilter]
    public class BaseController : Controller
    {
    }
}
