using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Models.CityAdministration;
using UtopiaCity.Services.CityAdministration;

namespace UtopiaCity.Controllers.CityAdministration
{
    public class RersidentAccountController : Controller
    {
        private readonly ResidentAccountService _residentAccountService;

        public RersidentAccountController(ResidentAccountService residentAccountService)
        {
            _residentAccountService = residentAccountService;
        }

        // view list of accounts
        public async Task<IActionResult> Index()
        {
            return View("Index", await _residentAccountService.GetRersidentAccounts());
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

            return View("Details", account);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(RersidentAccount newAccount)
        {
            if (ModelState.IsValid)
            {
                await _residentAccountService.AddRersidentAccount(newAccount);
                return RedirectToAction(nameof(Index));
            }

            return View("Create", newAccount);
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

            return View("Edit", account);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, RersidentAccount edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _residentAccountService.UpdateRersidentAccount(edited);
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", edited);
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

            return View("Delete", account);
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

            await _residentAccountService.DeleteRersidentAccount(account);
            return RedirectToAction(nameof(Index));
        }
    }
}
