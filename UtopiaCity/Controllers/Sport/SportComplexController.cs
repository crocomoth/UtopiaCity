using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.Sport;
using UtopiaCity.ViewModels.Sport;

namespace UtopiaCity.Controllers.Sport
{
    public class SportComplexController : Controller
    {
        private readonly SportComplexService _sportComplexService;
        private readonly IMapper _mapper;

        public SportComplexController(SportComplexService sportComplexService, IMapper mapper)
        {
            _sportComplexService = sportComplexService;
            _mapper = mapper;
        }

        public IActionResult AllSportComplexes()
        {
            List<SportComplex> sportComplexes = _sportComplexService.GetAllSportComplexes();
            List<SportComplexViewModel> sportComplexViewModels = new List<SportComplexViewModel>();
            foreach (SportComplex sportComplex in sportComplexes)
            {
                sportComplexViewModels.Add(_mapper.Map<SportComplexViewModel>(sportComplex));
            }

            return View(sportComplexViewModels);
        }

        public IActionResult Details(string id)
        {
            SportComplex sportComplex = _sportComplexService.GetSportComplexById(id);
            if (sportComplex == null)
            {
                return NotFound();
            }

            SportComplexViewModel sportComplexViewModel = _mapper.Map<SportComplexViewModel>(sportComplex);
            return View(sportComplexViewModel);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(SportComplexViewModel sportComplexViewModel)
        {
            if (sportComplexViewModel == null)
            {
                return View("Error", "You made mistakes while creating new Sport Complex");
            }

            SportComplex sportComplex = _mapper.Map<SportComplex>(sportComplexViewModel);
            _sportComplexService.AddSportComplexToDb(sportComplex);
            return RedirectToAction(nameof(AllSportComplexes));
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            SportComplex sportComplex = _sportComplexService.GetSportComplexById(id);
            if (sportComplex == null)
            {
                return NotFound();
            }

            SportComplexViewModel sportComplexViewModel = _mapper.Map<SportComplexViewModel>(sportComplex);
            return View(sportComplexViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            SportComplex sportComplex = _sportComplexService.GetSportComplexById(id);
            if (sportComplex == null)
            {
                return NotFound();
            }

            _sportComplexService.RemoveSportComplexFromDb(sportComplex);
            return RedirectToAction(nameof(AllSportComplexes));
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            SportComplex sportComplex = _sportComplexService.GetSportComplexById(id);
            if (sportComplex == null)
            {
                return NotFound();
            }

            SportComplexViewModel sportComplexViewModel = _mapper.Map<SportComplexViewModel>(sportComplex);
            return View(sportComplexViewModel);
        }

        [HttpPost]
        public IActionResult Edit(string id, SportComplexViewModel sportComplexViewModel)
        {
            if (id != sportComplexViewModel.SportComplexId)
            {
                return NotFound();
            }

            SportComplex sportComplex = _mapper.Map<SportComplex>(sportComplexViewModel);
            _sportComplexService.UpdateSportComplexInDb(sportComplex);
            return RedirectToAction(nameof(AllSportComplexes));
        }
    }
}