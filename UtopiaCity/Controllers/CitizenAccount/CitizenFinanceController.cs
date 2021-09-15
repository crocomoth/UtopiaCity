using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Data;
using System.Linq;
using UtopiaCity.Models.CitizenAccount;
using UtopiaCity.Services.CitizenAccount;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace UtopiaCity.Controllers.CitizenAccount
{
    [Authorize]
    public class CitizenFinanceController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly CitizensAccountService _citizensAccountService;
        private readonly CitizenFriendsService _citizenFriendsService;
        private readonly ApplicationDbContext _context;


        public CitizenFinanceController(UserManager<AppUser> userManager, CitizensAccountService citizensAccountService, CitizenFriendsService citizenFriendsService, ApplicationDbContext context)
        {
            _userManager = userManager;
            _citizensAccountService = citizensAccountService;
            _citizenFriendsService = citizenFriendsService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var currentuser = await _userManager.GetUserAsync(User);
            //var z=_context.AppUser.FirstOrDefault(x => x.UserName == currentuser.UserName).Balance;
            return View(currentuser);
        }

        [HttpGet]
        public IActionResult TopUpBalance()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TopUpBalance(Transaction transaction)
        {
            if (_context.AppUser.FirstOrDefault(x => x.UserName == transaction.RecipientsUsername) is null)
            {
                ViewBag.Message = "There is no such user";
                return View(transaction);
            }
            else
            {
                var user = _context.AppUser.FirstOrDefault(x => x.UserName == transaction.RecipientsUsername);
                user.Balance += transaction.Amount;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
