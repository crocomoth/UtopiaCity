using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Controllers.CitizenAccount
{
    public class CitizensTasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CitizensTasksController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CitizensTasks
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            ViewBag.userId = userId;
            var list = _context.CitizensTasks.Where(x=>x.UserId== userId).OrderBy(x=>x.ReminderDate);
            return View(await list.ToListAsync());
        }

        // GET: CitizensTasks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizensTask = await _context.CitizensTasks
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citizensTask == null)
            {
                return NotFound();
            }

            return View(citizensTask);
        }

        // GET: CitizensTasks/Create
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
                _context.Add(citizensTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(citizensTask);
        }

        // GET: CitizensTasks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizensTask = await _context.CitizensTasks.FindAsync(id);
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
            if (id != citizensTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(citizensTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(citizensTask);
        }

        // GET: CitizensTasks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizensTask = await _context.CitizensTasks
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citizensTask == null)
            {
                return NotFound();
            }

            return View(citizensTask);
        }

        // POST: CitizensTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var citizensTask = await _context.CitizensTasks.FindAsync(id);
            _context.CitizensTasks.Remove(citizensTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
