using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Controllers.CitizenAccount
{
    [Authorize]
    public class CitizensAccountController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        
        public CitizensAccountController(ApplicationDbContext dbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult ShowUserCabinet()
        {
            return View();
        }

        public async Task<IActionResult> IndexAsync()
        {
            AppUser user = await _userManager.GetUserAsync(User);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync()
        {
            AppUser report = await _userManager.GetUserAsync(User);

            if (report == null)
            {
                return NotFound();
            }
            return View("EditAppUserView", report);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, AppUser edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }
            AppUser user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                user.Name = edited.Name;
                user.Surname = edited.Surname;
                user.Gender = edited.Gender;
                user.DateOfBirth = edited.DateOfBirth;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(ShowUserCabinet));
            }
            return View("EditAppUserView", edited);
        }

        [HttpGet]
        public ActionResult DeleteAppUser()
        {
            return View();
        }

        [HttpPost]
        [ActionName("DeleteAppUser")]
        public async Task<ActionResult> DeleteConfirmed()
        {
            AppUser user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                await _signInManager.SignOutAsync();
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
