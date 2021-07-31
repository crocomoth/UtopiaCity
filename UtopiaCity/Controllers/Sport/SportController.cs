using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Services.Sport;

namespace UtopiaCity.Controllers.Sport
{
    public class SportController : Controller
    {
        private readonly SportComplexService _sportComplexService;
        private readonly SportEventService _sportEventService;

        public SportController(SportComplexService sportComplexService, SportEventService sportEventService)
        {
            _sportComplexService = sportComplexService;
            _sportEventService = sportEventService;
        }

        public IActionResult Index()
        {
            ViewBag.SportComplexes = _sportComplexService.GetAllSportComplexes();
            ViewBag.SportEvents = _sportEventService.GetAllSportEvents();
            return View();
        }
    }
}
