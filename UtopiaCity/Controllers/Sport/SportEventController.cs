using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UtopiaCity.Models.Sport;
using UtopiaCity.ViewModels.Sport;
using UtopiaCity.Services.Sport;
using AutoMapper;

namespace UtopiaCity.Controllers.Sport
{
    public class SportEventController : Controller
    {
        private readonly SportEventService _sportEventService;
        private readonly SportComplexService _sportComplexService;
        private readonly IMapper _mapper;

        public SportEventController(SportEventService sportEventService, SportComplexService sportComplexService, IMapper mapper)
        {
            _sportEventService = sportEventService;
            _sportComplexService = sportComplexService;
            _mapper = mapper;
        }

        public IActionResult AllSportEvents()
        {
            List<SportEvent> allSportEvents = _sportEventService.GetAllSportEvents();
            List<SportEventViewModel> sportEventViewModels = new List<SportEventViewModel>();
            foreach (var sportEvent in allSportEvents)
            {
                sportEventViewModels.Add(_mapper.Map<SportEventViewModel>(sportEvent));
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

            string sportComplexId = _sportComplexService.GetSportComplexIdByTitle(sportEventViewModel.SportComplexTitle);
            if (sportComplexId == null)
            {
                return View("Error", "Incorrect sport complex chosen." + Environment.NewLine + "Please, try again");
            }

            sportEventViewModel.SportComplexId = sportComplexId;
            SportEvent sportEvent = _mapper.Map<SportEvent>(sportEventViewModel);
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

            SportEventViewModel sportEventViewModel = _mapper.Map<SportEventViewModel>(sportEvent);
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

            SportEventViewModel sportEventViewModel = _mapper.Map<SportEventViewModel>(sportEvent);
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
            if (sportComplexId == null)
            {
                return View("Error", "Incorrect ID." + Environment.NewLine + "Please, try again.");
            }

            sportEventViewModel.SportComplexId = sportComplexId;
            SportEvent sportEvent = _mapper.Map<SportEvent>(sportEventViewModel);
            _sportEventService.UpdateSportEventInDb(sportEvent);
            return RedirectToAction(nameof(AllSportEvents));
        }

        public IActionResult Details(string id)
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

            SportEventViewModel sportEventViewModel = _mapper.Map<SportEventViewModel>(sportEvent);
            return View(sportEventViewModel);
        }
    }
}