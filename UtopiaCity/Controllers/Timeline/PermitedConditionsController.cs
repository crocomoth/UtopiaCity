using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtopiaCity.Models.TimelineModel;
using UtopiaCity.Services.Timeline;

namespace UtopiaCity.Controllers.Timeline
{
    public class PermitedConditionsController : Controller
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

        public async Task<IActionResult> FlashLight()
        {
            List<PermitedModel> model = new List<PermitedModel>();

            var data = _permitedConditionsService.GetList();


            return View("FlashLightView", await data);
        }
    }
}
