using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtopiaCity.Models.HousingSystem;
using UtopiaCity.Services.HousingSystem;

namespace UtopiaCity.Controllers.HousingSystem
{
    public class HousingSystemController : Controller
    {
        private readonly RealEstateService _realEstateService;
        public HousingSystemController(RealEstateService realEstateService)
        {
            this._realEstateService = realEstateService;
        }

        public async Task<IActionResult> Index()
        {
            return View("RealEstateListView", await _realEstateService.GetRealEstates());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var realEstate = await _realEstateService.GetRealEstateById(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            return View("DetailsRealEstateView", realEstate);
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
                await _realEstateService.AddRealEstate(newEstate);
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

            var realEstate = await _realEstateService.GetRealEstateById(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            return View("EditRealEstateView", realEstate);
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
                await _realEstateService.UpdateRealEstate(edited);
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

            var realEstate = await _realEstateService.GetRealEstateById(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            return View("DeleteRealEstateView", realEstate);
        }

        [HttpPost, ActionName("DeleteRealEstateView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var realEstate = await _realEstateService.GetRealEstateById(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            await _realEstateService.DeleteRealEstate(realEstate);
            return RedirectToAction(nameof(Index));
        }
    }
}
