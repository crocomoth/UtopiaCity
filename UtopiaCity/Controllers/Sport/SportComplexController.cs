using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UtopiaCity.Data;
using UtopiaCity.Models.Sport;

namespace UtopiaCity.Controllers.Sport
{
    public class SportComplexController : Controller
    {
        private ApplicationDbContext _dbContext;

        public SportComplexController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult AllSportComplexes() => View(_dbContext.SportComplex);

        public IActionResult Details(int ID)
        {
            var sportComplex = _dbContext.SportComplex.FirstOrDefault(x => x.ID.Equals(ID));
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
                _dbContext.Add(sportComplex);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(AllSportComplexes));
            }

            return View("Error", "You made mistakes while creating new Sport Complex");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var sportComplex = _dbContext.SportComplex.FirstOrDefault(s => s.ID.Equals(id));
            if (sportComplex == null)
            {
                return NotFound();
            }

            return View(sportComplex);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int ID)
        {
            var sportComplex = _dbContext.SportComplex.FirstOrDefault(x => x.ID.Equals(ID));
            if (sportComplex == null)
            {
                return NotFound();
            }

            _dbContext.Remove(sportComplex);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(AllSportComplexes));
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var sportComplex = _dbContext.SportComplex.FirstOrDefault(x => x.ID.Equals(ID));
            if (sportComplex == null)
            {
                return NotFound();
            }

            return View(sportComplex);
        }

        [HttpPost]
        public IActionResult Edit(int ID, SportComplex sportComplex)
        {
            if (ID != sportComplex.ID)
            {
                return NotFound();
            }

            _dbContext.SportComplex.Update(sportComplex);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(AllSportComplexes));
        }
    }
}
