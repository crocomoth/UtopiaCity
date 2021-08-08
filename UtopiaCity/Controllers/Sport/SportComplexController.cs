using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.Sport;
using UtopiaCity.ViewModels.Sport;

namespace UtopiaCity.Controllers.Sport
{
    public class SportComplexController : Controller
    {
        private readonly SportComplexService _sportComplexService;

        public SportComplexController(SportComplexService sportComplexService)
        {
            _sportComplexService = sportComplexService;
        }

        public IActionResult AllSportComplexes()
        {
            List<SportComplex> sportComplexes = _sportComplexService.GetAllSportComplexes();
            List<SportComplexViewModel> sportComplexViewModels = new List<SportComplexViewModel>();
            foreach(SportComplex sportComplex in sportComplexes)
            {
                sportComplexViewModels.Add(new SportComplexViewModel
                {
                    SportComplexId = sportComplex.SportComplexId,
                    SportComplexTitle = sportComplex.Title,
                    NumberOfSeats = sportComplex.NumberOfSeats,
                    BuildDate = sportComplex.BuildDate,
                    TypeOfSport = sportComplex.TypeOfSport,
                    Address = sportComplex.Address
                });
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

            SportComplexViewModel sportComplexViewModel = new SportComplexViewModel
            {
                SportComplexId = sportComplex.SportComplexId,
                SportComplexTitle = sportComplex.Title,
                NumberOfSeats = sportComplex.NumberOfSeats,
                BuildDate = sportComplex.BuildDate,
                TypeOfSport = sportComplex.TypeOfSport,
                Address = sportComplex.Address
            };

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

            SportComplex sportComplex = new SportComplex
            {
                SportComplexId = sportComplexViewModel.SportComplexId,
                Title = sportComplexViewModel.SportComplexTitle,
                NumberOfSeats = sportComplexViewModel.NumberOfSeats,
                BuildDate = sportComplexViewModel.BuildDate,
                TypeOfSport = sportComplexViewModel.TypeOfSport,
                Address = sportComplexViewModel.Address
            };

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

            SportComplexViewModel sportComplexViewModel = new SportComplexViewModel
            {
                SportComplexId = sportComplex.SportComplexId,
                SportComplexTitle = sportComplex.Title,
                NumberOfSeats = sportComplex.NumberOfSeats,
                BuildDate = sportComplex.BuildDate,
                TypeOfSport = sportComplex.TypeOfSport,
                Address = sportComplex.Address
            };

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

            SportComplexViewModel sportComplexViewModel = new SportComplexViewModel
            {
                SportComplexId = sportComplex.SportComplexId,
                SportComplexTitle = sportComplex.Title,
                NumberOfSeats = sportComplex.NumberOfSeats,
                BuildDate = sportComplex.BuildDate,
                TypeOfSport = sportComplex.TypeOfSport,
                Address = sportComplex.Address
            };

            return View(sportComplexViewModel);
        }

        [HttpPost]
        public IActionResult Edit(string id, SportComplexViewModel sportComplexViewModel)
        {
            if (id != sportComplexViewModel.SportComplexId)
            {
                return NotFound();
            }

            SportComplex sportComplex = new SportComplex
            {
                SportComplexId = sportComplexViewModel.SportComplexId,
                Title = sportComplexViewModel.SportComplexTitle,
                NumberOfSeats = sportComplexViewModel.NumberOfSeats,
                BuildDate = sportComplexViewModel.BuildDate,
                TypeOfSport = sportComplexViewModel.TypeOfSport,
                Address = sportComplexViewModel.Address
            };

            _sportComplexService.UpdateSportComplexInDb(sportComplex);
            return RedirectToAction(nameof(AllSportComplexes));
        }
    }
}