using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Sport;
using UtopiaCity.Models.Sport.ViewModels;
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

        public IActionResult AllSportEvents() => View(_sportEventService.GetAllSportEvents());

        [HttpGet]
        public IActionResult Create()
        {
            var sportEventViewModel = new SportEventViewModel
            {
                SportComplexesTitles = _sportComplexService.GetAllSportComplexesTitles()
            };
            return View(sportEventViewModel);
        }

        [HttpPost]
        public IActionResult Create(SportEventViewModel sportEventViewModel)
        {
            if (ModelState.IsValid && sportEventViewModel == null)
            {
                return View("Error", "You made mistakes while creating new Sport Event");
            }

            var sportComplex = _sportComplexService.GetSportComplexByTitle(sportEventViewModel.SportComplexTitle);
            if (sportComplex == null)
            {
                return View("Error", "Incorrect sport complex chosen." + Environment.NewLine + "Please, try again");
            }

            SportEvent sportEvent = new SportEvent
            {
                Title = sportEventViewModel.Title,
                DateOfTheEvent = sportEventViewModel.DateOfTheEvent,
                SportComplexId = sportComplex.SportComplexId
            };

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

            var sportEventViewModel = new SportEventViewModel
            {
                Title = sportEvent.Title,
                DateOfTheEvent = sportEvent.DateOfTheEvent,
                SportComplexTitle = sportComplex.Title,
                SportComplexAddress = sportComplex.Address
            };

            return View(sportEventViewModel);
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

            var sportEventViewModel = new SportEventViewModel
            {
                SportEventId = sportEvent.SportEventId,
                Title = sportEvent.Title,
                DateOfTheEvent = sportEvent.DateOfTheEvent,
                SportComplexId = sportComplex.SportComplexId,
                SportComplexTitle = sportComplex.Title,
                SportComplexAddress = sportComplex.Address,
                SportComplexesTitles = _sportComplexService.GetAllSportComplexesTitles()
            };

            return View(sportEventViewModel);
        }

        [HttpPost]
        public IActionResult Edit(string id, SportEventViewModel sportEventViewModel)
        {
            if (id == null)
            {
                return View("Error", "Incorrect ID." + Environment.NewLine + "Please, try again.");
            }
            else if (sportEventViewModel == null)
            {
                return View("Error", "Sport event not found." + Environment.NewLine + "Please, try again.");
            }

            var sportEvent = new SportEvent
            {
                SportEventId = sportEventViewModel.SportEventId,
                Title = sportEventViewModel.Title,
                DateOfTheEvent = sportEventViewModel.DateOfTheEvent,
                SportComplexId = _sportComplexService.GetSportComplexByTitle(sportEventViewModel.SportComplexTitle).SportComplexId
            };

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

            var sportEventViewModel = new SportEventViewModel
            {
                SportEventId = sportEvent.SportEventId,
                Title = sportEvent.Title,
                DateOfTheEvent = sportEvent.DateOfTheEvent,
                SportComplexId = sportEvent.SportComplexId,
                SportComplexTitle = sportComplex.Title,
                SportComplexAddress = sportComplex.Address
            };

            return View(sportEventViewModel);
        }
    }
}
