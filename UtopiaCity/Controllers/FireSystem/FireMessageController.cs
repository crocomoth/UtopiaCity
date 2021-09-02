using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.FireSystem;
using UtopiaCity.Services.FireSystem;

namespace UtopiaCity.Controllers.FireSystem
{
    public class FireMessageController : Controller
    {
        private readonly FireMessageService _fireMessageService;

        public FireMessageController(FireMessageService fireMessageService)
        {
            _fireMessageService = fireMessageService;
        }

        public async Task<IActionResult> Index()
        {
            return View("FireMessageListView", await _fireMessageService.GetFireMessages());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var message = await _fireMessageService.GetFireMessageById(id);
            if (message == null)
            {
                return NotFound();
            }

            return View("DetailsFireMessageView", message);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateFireMessageView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(FireMessage newMessage)
        {
            if (ModelState.IsValid)
            {
                await _fireMessageService.AddFireMessage(newMessage);
                return RedirectToAction(nameof(Index));
            }

            return View("CreateFireMessageView", newMessage);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var message = await _fireMessageService.GetFireMessageById(id);
            if (message == null)
            {
                return NotFound();
            }

            return View("EditFireMessageView", message);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, FireMessage edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _fireMessageService.UpdateFireMessage(edited);
                return RedirectToAction(nameof(Index));
            }

            return View("EditFireMessageView", edited);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var message = await _fireMessageService.GetFireMessageById(id);
            if (message == null)
            {
                return NotFound();
            }

            return View("DeleteFireMessageView", message);
        }

        public async Task<IActionResult> DeleteConfimed(string id)
        {
            var message = await _fireMessageService.GetFireMessageById(id);
            if (message == null)
            {
                return NotFound();
            }

            await _fireMessageService.DeleteFireMessage(message);
            return RedirectToAction(nameof(Index));
        }
    }
}
