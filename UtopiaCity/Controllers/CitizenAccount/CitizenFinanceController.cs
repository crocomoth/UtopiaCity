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
    /// <summary>
    /// Class represent citizen finance.
    /// </summary>
    [Authorize]
    public class CitizenFinanceController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly CitizensAccountService _citizensAccountService;
        private readonly CitizenFinanceService _citizenFinanceService;


        public CitizenFinanceController(UserManager<AppUser> userManager, CitizensAccountService citizensAccountService, CitizenFinanceService citizenFinanceService)
        {
            _userManager = userManager;
            _citizensAccountService = citizensAccountService;
            _citizenFinanceService = citizenFinanceService;
        }

        public async Task<IActionResult> Index()
        {
            var currentuser =await _userManager.GetUserAsync(User);
            return View(currentuser);
        }

        [HttpGet]
        public IActionResult TopUpBalance()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TopUpBalance(TransactionToTopUpViewModel transactionToTopUp)
        {

            if (_citizensAccountService.GetUserByUserName(transactionToTopUp.RecipientsUsername) is null)
            {
                ViewBag.Message = "There is no such user";
                return View(transactionToTopUp);
            }
            if (transactionToTopUp.Amount<=1)
            {
                ViewBag.Message = "Amount can't be less then 1";
                return View(transactionToTopUp);
            }
           
            var user = _citizensAccountService.GetUserByUserName(transactionToTopUp.RecipientsUsername);
            user.Balance += transactionToTopUp.Amount;
            _citizenFinanceService.CreateTransactionAndSave(transactionToTopUp, user);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task <IActionResult> Buy()
        {
            var currentuser =await _userManager.GetUserAsync(User);
            ViewBag.Balance = currentuser.Balance;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Buy(TransactionToBuyViewModel transactionToBuy)
        {
            var currentuser = await _userManager.GetUserAsync(User);
            if (transactionToBuy.UserBalance < transactionToBuy.Amount)
            {
                ViewBag.Message = "The purchase amount exceeds the balance";
                ViewBag.Balance = currentuser.Balance;
                return View(transactionToBuy);
            }
            if (transactionToBuy.Amount <= 1)
            {
                ViewBag.Message = "Amount can't be less then 1";
                ViewBag.Balance = currentuser.Balance;
                return View(transactionToBuy);
            }
            currentuser.Balance -= transactionToBuy.Amount;
            _citizenFinanceService.CreateTransactionAndSave(transactionToBuy, currentuser);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowPurchases()
        {
            var currentuser = await _userManager.GetUserAsync(User);
            return View(_citizenFinanceService.GetPurchases(currentuser.Id));
        }

        public async Task<IActionResult> ShowHistory()
        {
            var currentuser = await _userManager.GetUserAsync(User);
            return View(_citizenFinanceService.GetTransactionHistory(currentuser.Id));
        }
    }
}
