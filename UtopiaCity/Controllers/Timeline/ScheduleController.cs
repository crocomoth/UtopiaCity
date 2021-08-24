using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.TimelineModel.CollectionDataModel;
using UtopiaCity.Services.Timeline;

namespace UtopiaCity.Controllers.Timeline
{
    public class ScheduleController : Controller
    {
        private readonly ScheduleService _scheduleService;
        private readonly TimelineService _timelineService;
        ApplicationDbContext _context;

        public ScheduleController(ScheduleService scheduleService, TimelineService timelineService, ApplicationDbContext context)
        {
            _scheduleService = scheduleService;
            _timelineService = timelineService;
            _context = context;
        }

        //LIST
        //public async Task<IActionResult> Index()
        //{
        //    return View("ScheduleListView", await _scheduleService.GetFlights());
        //}

        public ViewResult Index(string name) => View(new CommonModel
        {
            Flight = _context.Flights
            .Where(i => i.Weather == name)
            .OrderBy(i => i.Id)
        });

    }
}
