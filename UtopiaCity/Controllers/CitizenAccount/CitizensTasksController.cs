using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UtopiaCity.Models.CitizenAccount;
using UtopiaCity.Services.CitizenAccount;

namespace UtopiaCity.Controllers.CitizenAccount
{
    [Authorize]
    public class CitizensTasksController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly CitizenTaskService _citizenTaskService;

        public CitizensTasksController(UserManager<AppUser> userManager, CitizenTaskService citizenTaskService)
        {
            _userManager = userManager;
            _citizenTaskService = citizenTaskService;
        }

        // GET: CitizensTasks
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            return View(await _citizenTaskService.GetTasksByReminderDate(userId));
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var citizensTask = await _citizenTaskService.GetTaskById(id);

            if (citizensTask == null)
            {
                return NotFound();
            }
            return View(citizensTask);
        }

        public IActionResult Create()
        {
            var userId = _userManager.GetUserId(User);
            ViewBag.userId = userId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CitizensTask citizensTask)
        {
            var userId = _userManager.GetUserId(User);
            ViewBag.userId = userId;
            if (citizensTask.ReminderDate<=DateTime.Now)
            {
                ViewBag.Message = "Reminder Date cannot be less than current date";
                return View(citizensTask);
            }
            if (ModelState.IsValid)
            {
                await _citizenTaskService.AddCitizenTask(citizensTask);
                return RedirectToAction(nameof(Index));
            }
            return View(citizensTask);
        }

        public async Task<IActionResult> Edit(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var citizensTask = await _citizenTaskService.GetTaskById(id);
            if (citizensTask == null)
            {
                return NotFound();
            }
            return View(citizensTask);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, CitizensTask citizensTask)
        {
            if (citizensTask.ReminderDate <= DateTime.Now)
            {
                ViewBag.Message = "Reminder Date cannot be less than current date";
                return View(citizensTask);
            }

            if (id != citizensTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _citizenTaskService.UpdateCitizenTask(citizensTask);
                return RedirectToAction(nameof(Index));
            }
            return View(citizensTask);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizensTask = await _citizenTaskService.GetTaskById(id);
            if (citizensTask == null)
            {
                return NotFound();
            }
            return View(citizensTask);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var citizensTask = await _citizenTaskService.GetTaskById(id);
            await _citizenTaskService.DeleteCitizenTask(citizensTask);
            return RedirectToAction(nameof(Index));
        }
    }
}
