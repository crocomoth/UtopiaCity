using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtopiaCity.Models.Energy;
using UtopiaCity.Services.Energy;

namespace UtopiaCity.Controllers.Energy
{
    public class EnergyCalculationsController : Controller
    {
        private readonly EnergyCalculationsService _energyCalculationsService;

        public EnergyCalculationsController(EnergyCalculationsService energyCalculationsService)
        {
            _energyCalculationsService = energyCalculationsService;
        }

        // view list of calculations
        public async Task<IActionResult> Index()
        {
            return View("EnergyListView", await _energyCalculationsService.GetEnergyCalculations());
        }

        // get specific item by id
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var report = await _energyCalculationsService.GetEnergyCalculationById(id);
            if (report == null)
            {
                return NotFound();
            }

            return View("EnergyDetailsView", report);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("EnergyCreateView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(EnergyCalculations newCalc)
        {
            if (ModelState.IsValid)
            {
                await _energyCalculationsService.AddEnergyCalculations(newCalc);
                return RedirectToAction(nameof(Index));
            }

            return View("EnergyCreateView", newCalc);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var calc = await _energyCalculationsService.GetEnergyCalculationById(id);
            if (calc == null)
            {
                return NotFound();
            }

            return View("EnergyEditView", calc);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EnergyCalculations edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _energyCalculationsService.UpdateEnergyCalculations(edited);
                return RedirectToAction(nameof(Index));
            }

            return View("", edited);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var calc = await _energyCalculationsService.GetEnergyCalculationById(id);
            if (calc == null)
            {
                return NotFound();
            }

            return View("EnergyDeleteView", calc);
        }

        [HttpPost, ActionName("EnergyDeleteView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var calc = await _energyCalculationsService.GetEnergyCalculationById(id);
            if (calc == null)
            {
                // TODO rewrite?
                return NotFound();
            }

            await _energyCalculationsService.DeleteEnergyCalculations(calc);
            return RedirectToAction(nameof(Index));
        }
    }
}
