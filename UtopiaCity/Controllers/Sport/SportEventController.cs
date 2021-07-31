using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Sport;
using UtopiaCity.ViewModels.Sport;
using UtopiaCity.Services.Sport;

namespace UtopiaCity.Controllers.Sport
{
    public class SportEventController : Controller
    {
        private readonly SportEventService _sportEventService;
        private readonly SportComplexService _sportComplexService;

        public SportEventController(SportEventService sportEventService, SportComplexService sportComplexService)
        {
            _sportEventService = sportEventService;
            _sportComplexService = sportComplexService;
        }

        public IActionResult AllSportEvents()
        {
            var allSportEvents = _sportEventService.GetAllSportEvents().ToList();
            var sportComplexEventViewModels = new List<SportComplexEventViewModel>();
            foreach(var sportEvent in allSportEvents)
            {
                sportComplexEventViewModels.Add(new SportComplexEventViewModel
                {
                    SportComplex = _sportComplexService.GetSportComplexById(sportEvent.SportComplexId),
                    SportEvent = sportEvent
                });
            }

            return View(sportComplexEventViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.SportComplexesTitles = _sportComplexService.GetAllSportComplexesTitles();
            return View();
        }

        [HttpPost]
        public IActionResult Create(SportComplexEventViewModel sportComplexEventViewModel)
        {
            if (sportComplexEventViewModel == null)
            {
                return View("Error", "You made mistakes while creating new Sport Event");
            }

            var sportComplex = _sportComplexService.GetSportComplexByTitle(sportComplexEventViewModel.SportComplex.Title);
            if (sportComplex == null)
            {
                return View("Error", "Incorrect sport complex chosen." + Environment.NewLine + "Please, try again");
            }

            SportEvent sportEvent = sportComplexEventViewModel.SportEvent;
            sportEvent.SportComplexId = sportComplex.SportComplexId;
            _sportEventService.AddSportEventToDb(sportEvent);
            return RedirectToAction(nameof(AllSportEvents));
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return View("Error", "Incorrect ID." + Environment.NewLine + "Please, try again.");
            }

            var sportEvent = _sportEventService.GetSportEventById(id);
            if (sportEvent == null)
            {
                return View("Error", "Sport event not found." + Environment.NewLine + "Please, try again.");
            }

            var sportComplex = _sportComplexService.GetSportComplexById(sportEvent.SportComplexId);

            var sportComplexEventViewModel = new SportComplexEventViewModel
            {
                SportComplex = sportComplex,
                SportEvent = sportEvent
            };

            return View(sportComplexEventViewModel);
        }
        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return View("Error", "Incorrect ID." + Environment.NewLine + "Please, try again.");
            }

            var sportEvent = _sportEventService.GetSportEventById(id);
            if (sportEvent == null)
            {
                return View("Error", "Sport event not found." + Environment.NewLine + "Please, try again.");
            }

            _sportEventService.RemoveSportEventFromDb(sportEvent);
            return RedirectToAction(nameof(AllSportEvents));
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return View("Error", "Incorrect ID." + Environment.NewLine + "Please, try again.");
            }

            var sportEvent = _sportEventService.GetSportEventById(id);
            if (sportEvent == null)
            {
                return View("Error", "Sport event not found." + Environment.NewLine + "Please, try again.");
            }

            var sportComplex = _sportComplexService.GetSportComplexById(sportEvent.SportComplexId);

            var sportComplexEventViewModel = new SportComplexEventViewModel
            {
                SportComplex = sportComplex,
                SportEvent = sportEvent
            };

            ViewBag.SportComplexesTitles = _sportComplexService.GetAllSportComplexesTitles();
            return View(sportComplexEventViewModel);
        }

        [HttpPost]
        public IActionResult Edit(string id, SportComplexEventViewModel sportComplexEventViewModel)
        {
            if (id == null)
            {
                return View("Error", "Incorrect ID." + Environment.NewLine + "Please, try again.");
            }
            else if (sportComplexEventViewModel == null)
            {
                return View("Error", "Sport event not found." + Environment.NewLine + "Please, try again.");
            }

            var sportComplex = _sportComplexService.GetSportComplexByTitle(sportComplexEventViewModel.SportComplex.Title);

            var sportEvent = sportComplexEventViewModel.SportEvent;
            sportEvent.SportComplexId = sportComplex.SportComplexId;

            _sportEventService.UpdateSportEventInDb(sportEvent);
            return RedirectToAction(nameof(AllSportEvents));
        }

        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return View("Error", "Incorrect ID." + Environment.NewLine + "Please, try again.");
            }

            var sportEvent = _sportEventService.GetSportEventById(id);
            if (sportEvent == null)
            {
                return View("Error", "Sport event not found." + Environment.NewLine + "Please, try again.");
            }

            var sportComplex = _sportComplexService.GetSportComplexById(sportEvent.SportComplexId);

            var sportComplexEventViewModel = new SportComplexEventViewModel
            {
                SportComplex = sportComplex,
                SportEvent = sportEvent
            };

            return View(sportComplexEventViewModel);
        }
    }
}
