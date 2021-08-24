using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Business;
using UtopiaCity.Services.Business;

namespace UtopiaCity.Controllers.Business
{
    public class BankController: Controller
    {
        private readonly BankService _bankService;

        public BankController(BankService bankService)
        {
            _bankService = bankService;
        }

        public async Task<IActionResult> Index()
        {
            return View("IndexView", await _bankService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bank bank)
        {
            if (ModelState.IsValid)
            {
                await _bankService.Create(bank);
                return RedirectToAction(nameof(Index));
            }

            return View("CreateView", bank);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var bank = await _bankService.GetById(id);
            if (bank == null)
            {
                return NotFound();
            }

            return View("EditView", bank);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, Bank bank)
        {
            if (id != bank.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _bankService.Update(bank);
                return RedirectToAction(nameof(Index));
            }

            return View("EditView", bank);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var bank = await _bankService.GetById(id);
            if (bank == null)
            {
                return NotFound();
            }

            return View("DeleteView", bank);
        }


        [HttpPost, ActionName("DeleteView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var bank = await _bankService.GetById(id);
            if (bank == null)
            {
                return NotFound();
            }

            await _bankService.Delete(bank);
            return RedirectToAction(nameof(Index));
        }
    }
}
