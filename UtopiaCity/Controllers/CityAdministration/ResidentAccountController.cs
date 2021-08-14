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
            return View("~/Views/CityAdministration/RersidentAccount/Index.cshtml", await _residentAccountService.GetRersidentAccounts());
        }

        // get specific item by id
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var account = await _residentAccountService.GetRersidentAccountById(id);
            if (account == null)
            {
                NotFound();
            }

            return View("~/Views/CityAdministration/RersidentAccount/Details.cshtml", account);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("~/Views/CityAdministration/RersidentAccount/Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ResidentAccount newAccount)
        {
            if (ModelState.IsValid)
            {
                await _residentAccountService.AddRersidentAccount(newAccount);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/CityAdministration/RersidentAccount/Create.cshtml", newAccount);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var account = await _residentAccountService.GetRersidentAccountById(id);
            if (account == null)
            {
                return NotFound();
            }

            return View("~/Views/CityAdministration/RersidentAccount/Edit.cshtml", account);
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
                await _residentAccountService.UpdateRersidentAccount(edited);
                await _marriageService.UpdateMarriageByAccount(edited);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/CityAdministration/RersidentAccount/Edit.cshtml", edited);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var account = await _residentAccountService.GetRersidentAccountById(id);
            if (account == null)
            {
                return NotFound();
            }

            return View("~/Views/CityAdministration/RersidentAccount/Delete.cshtml", account);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var account = await _residentAccountService.GetRersidentAccountById(id);
            if (account == null)
            {
                // TODO rewrite?
                return NotFound();
            }

            if (account.MarriageId != null)
            {
                await _marriageService.DeleteMarriage(await _marriageService.GetMarriageById(account.MarriageId));
            }

            await _residentAccountService.DeleteRersidentAccount(account);
            return RedirectToAction(nameof(Index));
        }
    }
}
