using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtopiaCity.Models.HousingSystem;
using UtopiaCity.Services.HousingSystem;

namespace UtopiaCity.Controllers.HousingSystem
{
    public class HousingSystemController : Controller
    {
        private readonly HousingSystemService _housingSystemService;
        public HousingSystemController(HousingSystemService housingSystemService)
        {
            _housingSystemService = housingSystemService;
        }

        // view list of estates 
        public async Task<IActionResult> Index()
        {
            return View("RealEstateListView", await _housingSystemService.GetRealEstatesList());
        }

        // get specific item by id
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var estate = _housingSystemService.GetRealEstateById(id);
            if (estate == null)
            {
                return NotFound();
            }

            return View("DetailsRealEstateView", await estate);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateRealEstateView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(RealEstate newEstate)
        {
            if (ModelState.IsValid)
            {
                await _housingSystemService.AddRealEstate(newEstate);
                return RedirectToAction(nameof(Index));
            }

            return View("CreateRealEstateView", newEstate);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var estate = await _housingSystemService.GetRealEstateById(id);
            if (estate == null)
            {
                return NotFound();
            }

            return View("EditRealEstateView", estate);
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
                await _housingSystemService.UpdateRealEstate(edited);
                return RedirectToAction(nameof(Index));
            }

            return View("EditRealEstateView", edited);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var estate = await _housingSystemService.GetRealEstateById(id);

            if (estate == null)
            {
                return NotFound();
            }

            return View("DeleteRealEstateView", estate);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var estate = await _housingSystemService.GetRealEstateById(id);
            if (estate == null)
            {
                // TODO rewrite?
                return NotFound();
            }

            await _housingSystemService.RemoveRealEstate(estate);
            return RedirectToAction(nameof(Index));
        }
    }
}
