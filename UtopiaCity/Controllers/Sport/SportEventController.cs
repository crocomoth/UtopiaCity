using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            List<SportEvent> allSportEvents = _sportEventService.GetAllSportEvents();
            List<SportEventViewModel> sportEventViewModels = new List<SportEventViewModel>();
            foreach (var sportEvent in allSportEvents)
            {
                sportEventViewModels.Add(new SportEventViewModel
                {
                    SportEventId = sportEvent.SportEventId,
                    SportEventTitle = sportEvent.Title,
                    DateOfTheEvent = sportEvent.DateOfTheEvent,
                    SportComplexId = sportEvent.SportComplexId,
                    SportComplexTitle = sportEvent.SportComplex.Title,
                    Address = sportEvent.SportComplex.Address
                });
            }

            return View(sportEventViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.SportComplexesTitles = _sportComplexService.GetAllSportComplexesTitles();
            return View();
        }

        [HttpPost]
        public IActionResult Create(SportEventViewModel sportEventViewModel)
        {
            if (sportEventViewModel == null)
            {
                return View("Error", "You made mistakes while creating new Sport Event");
            }

            //var sportComplex = _sportComplexService.GetSportComplexByTitle(sportEventViewModel.SportComplexTitle);
            string sportComplexId = _sportComplexService.GetSportComplexIdByTitle(sportEventViewModel.SportComplexTitle);
            if (sportComplexId == null)
            {
                return View("Error", "Incorrect sport complex chosen." + Environment.NewLine + "Please, try again");
            }

            SportEvent sportEvent = new SportEvent
            {
                Title = sportEventViewModel.SportEventTitle,
                DateOfTheEvent = sportEventViewModel.DateOfTheEvent,
                SportComplexId = sportComplexId
            };
            //sportEvent.SportComplexId = sportComplex.SportComplexId;
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

            SportEvent sportEvent = _sportEventService.GetSportEventByIdWithSportComplex(id);
            if (sportEvent == null)
            {
                return View("Error", "Sport event not found." + Environment.NewLine + "Please, try again.");
            }

            //var sportComplex = _sportComplexService.GetSportComplexById(sportEvent.SportComplexId);

            SportEventViewModel sportEventViewModel = new SportEventViewModel
            {
                SportEventId = sportEvent.SportEventId,
                SportEventTitle = sportEvent.Title,
                DateOfTheEvent = sportEvent.DateOfTheEvent,
                SportComplexId = sportEvent.SportComplexId,
                SportComplexTitle = sportEvent.SportComplex.Title,
                Address = sportEvent.SportComplex.Address
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

            SportEvent sportEvent = _sportEventService.GetSportEventById(id);
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

            SportEvent sportEvent = _sportEventService.GetSportEventById(id);
            if (sportEvent == null)
            {
                return View("Error", "Sport event not found." + Environment.NewLine + "Please, try again.");
            }

            //var sportComplex = _sportComplexService.GetSportComplexById(sportEvent.SportComplexId);

            SportEventViewModel sportEventViewModel = new SportEventViewModel
            {
                SportEventId = sportEvent.SportEventId,
                SportEventTitle = sportEvent.Title,
                DateOfTheEvent = sportEvent.DateOfTheEvent,
                SportComplexId = sportEvent.SportComplexId
            };

            ViewBag.SportComplexesTitles = _sportComplexService.GetAllSportComplexesTitles();
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

            string sportComplexId = _sportComplexService.GetSportComplexIdByTitle(sportEventViewModel.SportComplexTitle);

            SportEvent sportEvent = new SportEvent
            {
                SportEventId = sportEventViewModel.SportEventId,
                Title = sportEventViewModel.SportEventTitle,
                DateOfTheEvent = sportEventViewModel.DateOfTheEvent,
                SportComplexId = sportComplexId
            };
            //sportEvent.SportComplexId = sportComplex.SportComplexId;

            _sportEventService.UpdateSportEventInDb(sportEvent);
            return RedirectToAction(nameof(AllSportEvents));
        }

        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return View("Error", "Incorrect ID." + Environment.NewLine + "Please, try again.");
            }

            SportEvent sportEvent = _sportEventService.GetSportEventById(id);
            if (sportEvent == null)
            {
                return View("Error", "Sport event not found." + Environment.NewLine + "Please, try again.");
            }

            SportComplex sportComplex = _sportComplexService.GetSportComplexById(sportEvent.SportComplexId);

            SportEventViewModel sportEventViewModel = new SportEventViewModel
            {
                SportEventId = sportEvent.SportEventId,
                SportEventTitle = sportEvent.Title,
                DateOfTheEvent = sportEvent.DateOfTheEvent,
                SportComplexId = sportEvent.SportComplexId,
                SportComplexTitle = sportComplex.Title,
                Address = sportComplex.Address
            };

            return View(sportEventViewModel);
        }
    }
}