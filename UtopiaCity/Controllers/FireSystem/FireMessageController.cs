using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem;
using UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess;
using UtopiaCity.Services.FireSystem;

namespace UtopiaCity.Controllers.FireSystem
{
    public class FireMessageController : Controller
    {
        private readonly FireMessageService _fireMessageService;
        private readonly DepatureToThePlaceService _depatureToThePlace;
        public FireMessageController(FireMessageService fireMessageService, DepatureToThePlaceService depatureToThePlace)
        {
            _fireMessageService = fireMessageService;
            _depatureToThePlace = depatureToThePlace;
        }

        public async Task<IActionResult> Index()
        {
            return View("FireMessageListView", await _fireMessageService.GetFireMessages());
        }

        [HttpGet]
        public IActionResult Create()
        {   
            return View("CreateFireMessageView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(FireMessage newfireMessage)
        {
            if(newfireMessage == null)
            {
                return NotFound();
            }
            else if(newfireMessage == null)
            {
                return NotFound();
            }
            var freeDepartment = await _fireMessageService.GetFreeDepartmentAndChangeStatusOnBusy();
            var depature = new DepartureToThePlaceOfFire
            {
                Address = newfireMessage.Address,
                FullName = newfireMessage.FullName,
                PhoneNumber = newfireMessage.PhoneNumber,
                DepartmentId = freeDepartment.Id,
                Department = freeDepartment,
                FireMessage = newfireMessage,
                FireMessageId = newfireMessage.Id
            };
            newfireMessage.DepartureToThePlace = depature;
            var message = await _fireMessageService.AddFireMessage(newfireMessage);
            //TODO: timer(30 min)
            await _fireMessageService.SetFreeStatusOnDepartment(freeDepartment);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            FireMessage message = await _fireMessageService.GetFireMessageById(id);
            if (message == null)
            {
                return NotFound();
            }

            return View("DetailsFireMessageView", message);
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
            ViewData["DepartureToThePlaceId"] = new SelectList(await _fireMessageService.GetDepatures(), "Id", "Address");
            if (message == null)
            {
                return NotFound();
            }

            return View("DeleteFireMessageView", message);
        }

        [HttpPost, ActionName("DeleteFireMessageView")]
        public async Task<IActionResult> DeleteConfimed(string id)
        {
            var message = await _fireMessageService.GetFireMessageById(id);
            var depature = await _fireMessageService.GetDepatureByFireMessage(message);
            if (message == null)
            {
                return NotFound();
            }
            await _depatureToThePlace.DeleteDepature(depature);
            await _fireMessageService.DeleteFireMessage(message);
            return RedirectToAction(nameof(Index));
        }
    }
}
