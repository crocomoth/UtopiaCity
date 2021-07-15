using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtopiaCity.Services.Timeline;

namespace UtopiaCity.Controllers.Timeline
{
    public class TimelineBasicController : Controller
    {
        private readonly TimelineService _timelineService;

        public TimelineBasicController(TimelineService timelineService)
        {
            _timelineService = timelineService;
        }

        public async Task<IActionResult> Index()
        {
            return View("ListTimelineView", await _timelineService.GetList());
        }
    }
}
