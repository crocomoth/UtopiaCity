using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Models.CityAdministration;
using UtopiaCity.Services.CityAdministration;

namespace UtopiaCity.Controllers.CityAdministration
{
    public class ResidentAccountController : Controller
    {
        private readonly ResidentAccountService _residentAccountService;
        private readonly MarriageService _marriageService;

        public ResidentAccountController(ResidentAccountService residentAccountService, MarriageService marriageService)
        {
            _residentAccountService = residentAccountService;
            _marriageService = marriageService;
        }

        // view list of accounts
        public async Task<IActionResult> Index()
        {
            return View("~/Views/CityAdministration/ResidentAccount/Index.cshtml", await _residentAccountService.GetResidentAccounts());
        }

        // get specific item by id
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var account = await _residentAccountService.GetResidentAccountById(id);
            if (account == null)
            {
                NotFound();
            }

            return View("~/Views/CityAdministration/ResidentAccount/Details.cshtml", account);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("~/Views/CityAdministration/ResidentAccount/Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ResidentAccount newAccount)
        {
            if (ModelState.IsValid)
            {
                await _residentAccountService.AddResidentAccount(newAccount);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/CityAdministration/ResidentAccount/Create.cshtml", newAccount);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var account = await _residentAccountService.GetResidentAccountById(id);
            if (account == null)
            {
                return NotFound();
            }

            return View("~/Views/CityAdministration/ResidentAccount/Edit.cshtml", account);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ResidentAccount edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _residentAccountService.UpdateResidentAccount(edited);
                await _marriageService.UpdateMarriageByAccount(edited);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/CityAdministration/ResidentAccount/Edit.cshtml", edited);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var account = await _residentAccountService.GetResidentAccountById(id);
            if (account == null)
            {
                return NotFound();
            }

            return View("~/Views/CityAdministration/ResidentAccount/Delete.cshtml", account);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var account = await _residentAccountService.GetResidentAccountById(id);
            if (account == null)
            {
                // TODO rewrite?
                return NotFound();
            }

            if (account.MarriageId != null)
            {
                await _marriageService.DeleteMarriage(await _marriageService.GetMarriageById(account.MarriageId));
            }

            await _residentAccountService.DeleteResidentAccount(account);
            return RedirectToAction(nameof(Index));
        }
    }
}
