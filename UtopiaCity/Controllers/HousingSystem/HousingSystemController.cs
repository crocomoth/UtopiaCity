using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.HousingSystem;

namespace UtopiaCity.Controllers.HousingSystem
{
    public class HousingSystemController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HousingSystemController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // view list of estates 
        public async Task<IActionResult> Index()
        {
            return View("RealEstateListView", await _dbContext.RealEstate.ToListAsync());
        }

        // get specific item by id
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var estate = await _dbContext.RealEstate.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (estate == null)
            {
                return NotFound();
            }

            return View(estate);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RealEstate newEstate)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(newEstate);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(newEstate);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var estate = _dbContext.RealEstate.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (estate == null)
            {
                return NotFound();
            }

            return View(estate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, RealEstate edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dbContext.Update(edited);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(edited);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var estate = _dbContext.RealEstate.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (estate == null)
            {
                return NotFound();
            }

            return View(estate);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var estate = _dbContext.RealEstate.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (estate == null)
            {
                // TODO rewrite?
                return NotFound();
            }

            _dbContext.Remove(estate);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
