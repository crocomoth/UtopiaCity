using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Services.Life;
using UtopiaCity.Services.Sport;
using UtopiaCity.Models.Life;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace UtopiaCity.Controllers.Sport
{
    [Authorize]
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
            var eventDto = new EventDto { EventType = (int)EventType.sports };
            ViewBag.SportAchievements = _lifeService.Search(eventDto).ToList();
            return View();
        }
    }
}