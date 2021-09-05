using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.Sport;
using UtopiaCity.ViewModels.Sport;

namespace UtopiaCity.Controllers.Sport
{
    public class RequestToAdministrationController : Controller
    {
        private readonly RequestToAdministrationService _requestToAdministrationService;
        private readonly SportComplexService _sportComplexService;
        private readonly IMapper _mapper;

        public RequestToAdministrationController
            (RequestToAdministrationService requestToAdministrationService, SportComplexService sportComplexService, IMapper mapper)
        {
            _requestToAdministrationService = requestToAdministrationService;
            _sportComplexService = sportComplexService;
            _mapper = mapper;
        }

        public async Task<IActionResult> AllRequestsToAdministration()
        {
            var allRequests = _requestToAdministrationService.GetAllRequestsToAdministration();
            var requestToAdministrationViewModels = _requestToAdministrationService.CreatingRequestToAdministationViewModel(allRequests, _mapper);
            ViewBag.SportComplexesIds = await _sportComplexService.GetAllSportComplexesIds();
            ViewBag.IsAllRequestToAdministrationPrinted = true;
            return View(requestToAdministrationViewModels);
        }

        public IActionResult AllRequestsToAdministrationByDate(DateTime date)
        {
            var allRequests = _requestToAdministrationService.GetRequestsToAdministrationByDate(date);
            var requestToAdministrationViewModels = _requestToAdministrationService.CreatingRequestToAdministationViewModel(allRequests, _mapper);
            ViewBag.IsAllRequestToAdministrationPrinted = false;
            return View("AllRequestsToAdministration", requestToAdministrationViewModels);
        }

        public IActionResult AllRequestsToAdministrationBySportComplexId(string id)
        {
            var allRequests = _requestToAdministrationService.GetRequestsToAdministrationBySportComplexId(id);
            var requestToAdministrationViewModels = _requestToAdministrationService.CreatingRequestToAdministationViewModel(allRequests, _mapper);
            ViewBag.IsAllRequestToAdministrationPrinted = false;
            return View("AllRequestsToAdministration", requestToAdministrationViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.SportComplexesTitles = await _sportComplexService.GetAllSportComplexesTitles();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RequestToAdministrationViewModel requestViewModel)
        {
            if (!ModelState.IsValid || requestViewModel == null)
            {
                return View("Error", "Some problems with the input information. Please, try again");
            }

            string sportComplexId = await _sportComplexService.GetSportComplexIdByTitle(requestViewModel.SportComplexTitle);
            if (sportComplexId == null)
            {
                return View("Error", "Some problems with the sport complex data. Please, try again");
            }

            requestViewModel.SportComplexId = sportComplexId;
            requestViewModel.DateOfRequest = DateTime.Now;
            var request = _mapper.Map<RequestToAdministration>(requestViewModel);
            _requestToAdministrationService.AddRequestToDb(request);
            return RedirectToAction(nameof(AllRequestsToAdministration));
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return View("Error", "The id is incorrect. Please, try again");
            }

            RequestToAdministration request = _requestToAdministrationService.GetRequestToAdministrationById(id);
            if (request == null)
            {
                return View("Error", "The request is not found. Please, try again");
            }

            var requestViewModel = _mapper.Map<RequestToAdministrationViewModel>(request);
            return View(requestViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return View("Error", "The id is incorrect. Please, try again");
            }

            RequestToAdministration request = _requestToAdministrationService.GetRequestToAdministrationById(id);
            if (request == null)
            {
                return View("Error", "The request is not found. Please, try again");
            }

            _requestToAdministrationService.RemoveRequestFromDb(request);
            return RedirectToAction(nameof(AllRequestsToAdministration));
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return View("Error", "The id is incorrect. Please, try again");
            }

            RequestToAdministration request = _requestToAdministrationService.GetRequestToAdministrationById(id);
            if (request == null)
            {
                return View("Error", "The request is not found. Please, try again");
            }

            var requestViewModel = _mapper.Map<RequestToAdministrationViewModel>(request);
            return View(requestViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, RequestToAdministrationViewModel requestViewModel)
        {
            if (id == null)
            {
                return View("Error", "The id is incorrect. Please, try again");
            }
            else if (requestViewModel == null)
            {
                return View("Error", "Some errors in input data. Please, try again");
            }

            SportComplex sportComplex = await _sportComplexService.GetSportComplexByTitle(requestViewModel.SportComplexTitle);
            if (sportComplex == null)
            {
                return View("Error", "Some problems with the sport complex data. Please, try again");
            }

            if (requestViewModel.IsApproved)
            {
                sportComplex.Available = true;
            }
            else
            {
                sportComplex.Available = false;
            }

            if (!requestViewModel.IsReviewed)
            {
                requestViewModel.IsReviewed = true;
            }

            requestViewModel.SportComplexId = sportComplex.SportComplexId;
            await _sportComplexService.UpdateSportComplexInDb(sportComplex);
            var request = _mapper.Map<RequestToAdministration>(requestViewModel);
            _requestToAdministrationService.UpdateRequestInDb(request);
            return RedirectToAction(nameof(AllRequestsToAdministration));
        }

        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return View("Error", "The id is incorrect. Please, try again");
            }

            RequestToAdministration request = _requestToAdministrationService.GetRequestToAdministrationById(id);
            if (request == null)
            {
                return View("Error", "The request is not found. Please, try again");
            }

            var requestViewModel = _mapper.Map<RequestToAdministrationViewModel>(request);
            return View(requestViewModel);
        }
    }
}
