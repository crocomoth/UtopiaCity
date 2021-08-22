using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.CitizenAccount;
using UtopiaCity.Services.Sport;
using UtopiaCity.ViewModels.Sport;

namespace UtopiaCity.Controllers.Sport
{
    public class SportTicketController : Controller
    {
        private readonly SportTicketService _sportTicketService;
        private readonly SportComplexService _sportComplexService;
        private readonly SportEventService _sportEventService;
        private readonly CitizensAccountService _appUserService;
        private readonly IMapper _mapper;
        private readonly string _userId;

        public SportTicketController(SportTicketService sportTicketService, SportComplexService sportComplexService, SportEventService sportEventService,
            CitizensAccountService appUserService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _sportTicketService = sportTicketService;
            _sportComplexService = sportComplexService;
            _sportEventService = sportEventService;
            _appUserService = appUserService;
            _mapper = mapper;
            _userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public IActionResult AllSportTickets()
        {
            List<SportTicket> sportTickets = _sportTicketService.GetAllSportTickets();
            var sportTicketsViewModels = new List<SportTicketViewModel>();
            foreach (var sportTicket in sportTickets)
            {
                sportTicketsViewModels.Add(_mapper.Map<SportTicketViewModel>(sportTicket));
            }

            return View(sportTicketsViewModels);
        }

        [HttpGet]
        public IActionResult Create(string id)
        {
            //ViewBag.SportEventsTitles = _sportEventService.GetAllSportEventsTitles();
            if(id == null)
            {
                return View("Error", "Incorrect Id. Please, try again");
            }

            SportEvent sportEvent = _sportEventService.GetSportEventByIdWithSportComplex(id);
            SportTicket sportTicket = new SportTicket
            {
                SportComplexId = sportEvent.SportComplex.SportComplexId,
                SportEventId = sportEvent.SportEventId,
                AppUserId = _userId,
                SportComplex = sportEvent.SportComplex,
                SportEvent = sportEvent,
                AppUser = _appUserService.GetUserById(_userId).Result
            };
            //Try use AJAX without viewModel
            var sportTicketViewModel = _mapper.Map<SportTicketViewModel>(sportTicket);
            return View(sportTicketViewModel);
        }

        [HttpPost]
        public IActionResult Create(SportTicketViewModel sportTicketViewModel)
        {
            if (sportTicketViewModel == null)
            {
                return View("Error", "You made mistakers while creating new Sport Ticket. Please, try again");
            }

            string sportComplexId = _sportComplexService.GetSportComplexIdByTitle(sportTicketViewModel.SportComplexTitle);
            if (sportComplexId == null)
            {
                return View("Error", "Incorrect sport complex chosen." + Environment.NewLine + "Please, try again");
            }

            string sportEventId = _sportEventService.GetSportEventIdByTitle(sportTicketViewModel.SportEventTitle);
            if (sportEventId == null)
            {
                return View("Error", "Incorrect sport event chosen." + Environment.NewLine + "Please, try again");
            }

            //string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var sportTicket = _mapper.Map<SportTicket>(sportTicketViewModel);
            sportTicket.SportComplexId = sportComplexId;
            sportTicket.SportEventId = sportEventId;
            sportTicket.AppUserId = _userId;
            _sportTicketService.AddSportTicketToDb(sportTicket);
            return RedirectToAction(nameof(AllSportTickets));
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return View("Error", "Incorrect ID." + Environment.NewLine + "Please, try again");
            }

            SportTicket sportTicket = _sportTicketService.GetSportTicketById(id);
            if (sportTicket == null)
            {
                return View("Error", "Sport ticket not found." + Environment.NewLine + "Please, try again");
            }

            SportTicketViewModel sportTicketViewModel = _mapper.Map<SportTicketViewModel>(sportTicket);
            return View(sportTicketViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return View("Error", "Incorrect ID." + Environment.NewLine + "Please, try again");
            }

            SportTicket sportTicket = _sportTicketService.GetSportTicketById(id);
            if (sportTicket == null)
            {
                return View("Error", "Sport ticket not found." + Environment.NewLine + "Please, try again");
            }

            _sportTicketService.RemoveSportTicketFromDb(sportTicket);
            return RedirectToAction(nameof(AllSportTickets));
        }

        /*[HttpGet]
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return View("Error", "Incorrect ID." + Environment.NewLine + "Please, try again");
            }

            SportTicket sportTicket = _sportTicketService.GetSportTicketById(id);
            if (sportTicket == null)
            {
                return View("Error", "Sport ticket not found." + Environment.NewLine + "Please, try again");
            }

            var sportTicketViewModel = _mapper.Map<SportTicketViewModel>(sportTicket);
            return View(sportTicketViewModel);
        }

        [HttpPost]
        public IActionResult Edit(string id, SportTicketViewModel sportTicketViewModel)
        {
            if (id == null)
            {
                return View("Error", "Incorrect ID." + Environment.NewLine + "Please, try again");
            }
            else if (sportTicketViewModel == null)
            {
                return View("Error", "You made mistakers while creating new Sport Ticket. Please, try again");
            }

            string sportComplexId = _sportComplexService.GetSportComplexIdByTitle(sportTicketViewModel.SportComplexTitle);
            if (sportComplexId == null)
            {
                return View("Error", "Incorrect sport complex chosen." + Environment.NewLine + "Please, try again");
            }

            string sportEventId = _sportEventService.GetSportEventIdByTitle(sportTicketViewModel.SportEventTitle);
            if (sportEventId == null)
            {
                return View("Error", "Incorrect sport event chosen." + Environment.NewLine + "Please, try again");
            }

            //string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var sportTicket = _mapper.Map<SportTicket>(sportTicketViewModel);
            sportTicket.SportComplexId = sportComplexId;
            sportTicket.SportEventId = sportEventId;
            sportTicket.AppUserId = _userId;
            _sportTicketService.UpdateSportTicketInDb(sportTicket);
            return RedirectToAction(nameof(AllSportTickets));
        }*/

        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return View("Error", "Incorrect ID." + Environment.NewLine + "Please, try again");
            }

            SportTicket sportTicket = _sportTicketService.GetSportTicketById(id);
            if (sportTicket == null)
            {
                return View("Error", "Sport ticket not found." + Environment.NewLine + "Please, try again");
            }

            var sportTicketViewModel = _mapper.Map<SportTicketViewModel>(sportTicket);
            return View(sportTicketViewModel);
        }
    }
}
