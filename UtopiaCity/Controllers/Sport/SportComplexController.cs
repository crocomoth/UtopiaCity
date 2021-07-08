using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.Sport;

namespace UtopiaCity.Controllers.Sport
{
    public class SportComplexController : Controller
    {
        private readonly SportComplexService _sportComplexService;

        public SportComplexController(SportComplexService sportComplexService)
        {
            _sportComplexService = sportComplexService;
        }

        public IActionResult AllSportComplexes() => View(_sportComplexService.GetAllSportComplexes());

        public IActionResult Details(int id)
        {
            var sportComplex = _sportComplexService.GetSportComplexById(id);
            if (sportComplex == null)
            {
                return NotFound();
            }

            return View(sportComplex);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(SportComplex sportComplex)
        {
            if (ModelState.IsValid && sportComplex != null)
            {
                _sportComplexService.AddSportComplexToDb(sportComplex);
                return RedirectToAction(nameof(AllSportComplexes));
            }

            return View("Error", "You made mistakes while creating new Sport Complex");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var sportComplex = _sportComplexService.GetSportComplexById(id);
            if (sportComplex == null)
            {
                return NotFound();
            }

            return View(sportComplex);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var sportComplex = _sportComplexService.GetSportComplexById(id);
            if (sportComplex == null)
            {
                return NotFound();
            }

            _sportComplexService.RemoveSportComplexFromDb(sportComplex);
            return RedirectToAction(nameof(AllSportComplexes));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var sportComplex = _sportComplexService.GetSportComplexById(id);
            if (sportComplex == null)
            {
                return NotFound();
            }

            return View(sportComplex);
        }

        [HttpPost]
        public IActionResult Edit(int id, SportComplex sportComplex)
        {
            if (id != sportComplex.Id)
            {
                return NotFound();
            }

            _sportComplexService.UpdateSportComplexInDb(sportComplex);
            return RedirectToAction(nameof(AllSportComplexes));
        }
    }
}
