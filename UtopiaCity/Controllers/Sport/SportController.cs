using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Services.Life;
using UtopiaCity.Services.Sport;
using UtopiaCity.Models.Life;
using System.Threading.Tasks;

namespace UtopiaCity.Controllers.Sport
{
    public class SportController : Controller
    {
        private readonly SportComplexService _sportComplexService;
        private readonly SportEventService _sportEventService;
        private readonly LifeService _lifeService;

        public SportController(SportComplexService sportComplexService, SportEventService sportEventService, LifeService lifeService)
        {
            _sportComplexService = sportComplexService;
            _sportEventService = sportEventService;
            _lifeService = lifeService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SportComplexes = await _sportComplexService.GetAllSportComplexes();
            ViewBag.SportEvents = await _sportEventService.GetAllSportEvents();
            //ViewBag.SportAchievements = _lifeService.GetByEventType(EventType.Sport);
            return View();
        }
    }
}