using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Models.CityAdministration;
using UtopiaCity.Services.CityAdministration;

namespace UtopiaCity.Controllers.CityAdministration
{
    public class MarriageController : Controller
    {
        private readonly MarriageService _marriageService;

        public MarriageController(MarriageService marriageService)
        {
            _marriageService = marriageService;
        }

        // GET: Marriage
        public async Task<IActionResult> Index()
        {
            return View("~/Views/CityAdministration/Marriage/Index.cshtml", await _marriageService.GetMarriages());
        }

        // GET: Marriage/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var marriage = await _marriageService.GetMarriageById(id);
            if (marriage == null)
            {
                return NotFound();
            }

            return View("~/Views/CityAdministration/Marriage/Details.cshtml", marriage);
        }

        // GET: Marriage/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("~/Views/CityAdministration/Marriage/Create.cshtml", await _marriageService.GetNewViewModel());
        }

        // POST: Marriage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewModel viewModel)
        {
            var marriage = new Marriage();

            if (ModelState.IsValid)
            {
                await _marriageService.GetMarriageFromViewAsync(viewModel, marriage);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/CityAdministration/Marriage/Create.cshtml", await _marriageService.GetNewViewModel());
        }


        // GET: Marriage/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var marriage = await _marriageService.GetMarriageById(id);
            if (marriage == null)
            {
                return NotFound();
            }

            return View("~/Views/CityAdministration/Marriage/Edit.cshtml", await _marriageService.GetViewModel(id, marriage));
        }

        // POST: Marriage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string Id, ViewModel edited)
        {
            if (Id != edited.MarriageId)
            {
                return NotFound();
            }

            var marriage = await _marriageService.GetMarriageById(Id);

            if (ModelState.IsValid)
            {
                await _marriageService.GetMarriageFromViewAsync(edited, marriage);
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/CityAdministration/Marriage/Edit.cshtml", edited);
        }

        // GET: Marriage/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marriage = await _marriageService.GetMarriageById(id);
            if (marriage == null)
            {
                return NotFound();
            }

            return View("~/Views/CityAdministration/Marriage/Delete.cshtml", marriage);
        }

        // POST: Marriage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var marriage = await _marriageService.GetMarriageById(id);
            if (marriage == null)
            {
                // TODO rewrite?
                return NotFound();
            }
            await _marriageService.DeleteMarriage(marriage);
            return RedirectToAction(nameof(Index));
        }
    }
}
