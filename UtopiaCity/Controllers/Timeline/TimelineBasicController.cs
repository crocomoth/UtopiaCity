using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;
using UtopiaCity.Models.Life;
using UtopiaCity.Models.TimelineModel;
using UtopiaCity.Models.TimelineModel.CollectionDataModel;
using UtopiaCity.Services.Airport;
using UtopiaCity.Services.Life;
using UtopiaCity.Services.Timeline;

namespace UtopiaCity.Controllers.Timeline
{
    public class TimelineBasicController : Controller
    {
        private readonly TimelineService _timelineService;
        private readonly FlightService _flightService;
        private readonly LifeService _lifeService;
        private readonly ApplicationDbContext _dbContext;
        public TimelineBasicController(TimelineService timelineService, FlightService flightService, LifeService lifeService, ApplicationDbContext dbContext)
        {
            _lifeService = lifeService;
            _flightService = flightService;
            _timelineService = timelineService;
            _dbContext = dbContext;
        }

        //LIST
        public async Task<IActionResult> Index()
        {
            return View("ListTimelineView", await _timelineService.GetList());
        }
        //CREATE
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(TimelineModel newEvent)
        {
            if (ModelState.IsValid)
            {
                await _timelineService.CreateNewEvent(newEvent);
                return RedirectToAction(nameof(Index));
            }

            return View("Create", newEvent);
        }


        //EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }

            var chosenEvent = await _timelineService.GetEventById(id);
            if (chosenEvent is null)
            {
                return BadRequest();
            }

            return View("EditTimelineView", chosenEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, TimelineModel chosenEvent)
        {
            if (id != chosenEvent.ID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _timelineService.EditEvent(chosenEvent);
                return RedirectToAction(nameof(Index));
            }

            return View("EditTimelineView", chosenEvent);
        }

        //DELETE 
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var chosenEvent = await _timelineService.GetEventById(id);
            if (chosenEvent is null)
            {
                return NotFound();
            }

            return View("DeleteTimelineView", chosenEvent);
        }

        [HttpPost, ActionName("DeleteTimelineView")]
        public async Task<IActionResult> DeleteWithPostMethod(string id)
        {
            var chosenEvent = await _timelineService.GetEventById(id);
            if (chosenEvent is null)
            {
                return NotFound();
            }

            await _timelineService.DeleteEvent(chosenEvent);
            return RedirectToAction(nameof(Index));
        }

        //DETAILS
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var chosenEvent = await _timelineService.GetEventById(id);
            if (chosenEvent is null)
            {
                return NotFound();
            }

            return View("DetailsTimelineView", chosenEvent);
        }

        //VIEW DATA 
        public ActionResult ViewModelResult()
        {
            CollectionDataModel dataViewModel = new CollectionDataModel();

            List<Flight> flights = _flightService.GetFlightList();

            List<Event> events = _lifeService.GetAll();

            dataViewModel._flights = flights;

            dataViewModel._events = events;

            return View(dataViewModel);
        }


        public async Task<IActionResult> Searching(string searchString)
        {
            var searchResult = from t in _dbContext.Flights
                               select t;
            if (!string.IsNullOrEmpty(searchString))
            {
                searchResult = searchResult.Where(i => i.LocationPoint.Contains(searchString) || i.DestinationPoint.Contains(searchString));
            }

            return View(await searchResult.ToListAsync());
        }
    }
}
