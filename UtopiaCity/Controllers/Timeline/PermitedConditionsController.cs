using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtopiaCity.Services.Timeline;

namespace UtopiaCity.Controllers.Timeline
{
    public class PermitedConditionsController:Controller
    {
        private readonly PermitedConditonsService _permitedConditionsService;

        public PermitedConditionsController(PermitedConditonsService permitedConditionsService)
        {
            _permitedConditionsService = permitedConditionsService;
        }

        //LIST
        public async Task<IActionResult> Index()
        {
            return View("PermitedConditonsView", await _permitedConditionsService.GetList());
        }
    }
}
