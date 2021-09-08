using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IActionResult> AllSportComplexes()
        {
            List<SportComplex> sportComplexes = await  _sportComplexService.GetAllSportComplexes();
            List<SportComplexViewModel> sportComplexViewModels = new List<SportComplexViewModel>();
            foreach (SportComplex sportComplex in sportComplexes)
            {
                sportComplexViewModels.Add(_mapper.Map<SportComplexViewModel>(sportComplex));
            }

            return View(sportComplexViewModels);
        }

        public async Task<IActionResult> Details(string id)
        {
            SportComplex sportComplex = await _sportComplexService.GetSportComplexById(id);
            if (sportComplex == null)
            {
                return View("Error", "Invalid id");
            }

            SportComplexViewModel sportComplexViewModel = _mapper.Map<SportComplexViewModel>(sportComplex);
            return View(sportComplexViewModel);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(SportComplexViewModel sportComplexViewModel)
        {
            if (sportComplexViewModel == null)
            {
                return View("Error", "You made mistakes while creating new Sport Complex");
            }

            SportComplex sportComplex = _mapper.Map<SportComplex>(sportComplexViewModel);
            await _sportComplexService.AddSportComplexToDb(sportComplex);
            return RedirectToAction(nameof(AllSportComplexes));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("Error", "Invalid id");
            }

            SportComplex sportComplex = await _sportComplexService.GetSportComplexById(id);
            if (sportComplex == null)
            {
                return View("Error", "Sport complex not found");
            }

            SportComplexViewModel sportComplexViewModel = _mapper.Map<SportComplexViewModel>(sportComplex);
            return View(sportComplexViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("Error", "Invalid id");
            }

            SportComplex sportComplex = await _sportComplexService.GetSportComplexById(id);
            if (sportComplex == null)
            {
                return View("Error", "Sport complex not found");
            }

            await _sportComplexService.RemoveSportComplexFromDb(sportComplex);
            return RedirectToAction(nameof(AllSportComplexes));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("Error", "Invalid id");
            }

            SportComplex sportComplex = await _sportComplexService.GetSportComplexById(id);
            if (sportComplex == null)
            {
                return View("Error", "Sport complex not found");
            }

            SportComplexViewModel sportComplexViewModel = _mapper.Map<SportComplexViewModel>(sportComplex);
            return View(sportComplexViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, SportComplexViewModel sportComplexViewModel)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("Error", "Invalid id");
            }
            else if (sportComplexViewModel == null)
            {
                return View("Error", "Invalid sport complex");
            }
            else if (id != sportComplexViewModel.SportComplexId)
            {
                return View("Error", "Not equals ids");
            }

            SportComplex sportComplex = _mapper.Map<SportComplex>(sportComplexViewModel);
            await _sportComplexService.UpdateSportComplexInDb(sportComplex);
            return RedirectToAction(nameof(AllSportComplexes));
        }
    }
}