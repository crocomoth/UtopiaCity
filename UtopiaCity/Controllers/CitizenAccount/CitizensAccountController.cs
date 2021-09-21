using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;
using UtopiaCity.Services.CitizenAccount;

namespace UtopiaCity.Controllers.CitizenAccount
{
    [Authorize]
    public class CitizensAccountController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ServicesForOtherStudents _servicesForOtherStudents;

        public CitizensAccountController(ApplicationDbContext dbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ServicesForOtherStudents servicesForOtherStudents)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _servicesForOtherStudents = servicesForOtherStudents;
        }

        public async Task<IActionResult> IndexAsync()
        {
            AppUser user = await _userManager.GetUserAsync(User);
            return View(nameof(IndexAsync), user);
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AppUser userForEdit = await _userManager.GetUserAsync(User);

            if (userForEdit == null)
            {
                return NotFound();
            }
            return View(userForEdit);
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(string id, AppUser edited)
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
                return RedirectToAction("Index");
            }
            return View(nameof(EditAsync), edited);
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

        [HttpGet]
        public ActionResult BlockUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BlockUser(string userId)
        {
            _servicesForOtherStudents.BlockCitizenAccount(userId);
            return RedirectToAction("Index", "Home");
        }
    }
}
