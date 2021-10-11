using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using UtopiaCity.Models.Media;
using UtopiaCity.Models.Media.Account;
using UtopiaCity.Services.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using UtopiaCity.Models.Media.Responses;
using UtopiaCity.Helpers;
using UtopiaCity.Models.Media.Requests;

namespace UtopiaCity.Controllers.Media
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View(@"~/Views/Media/LoginAccountView.cshtml");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(@"~/Views/Media/CreateAccountView.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            if (ModelState.IsValid)
            {
                var user = await _accountService.Register(model);
                await Authenticate(user);

                return RedirectToAction("~/Views/Media/LoginAccountView.cshtml");
            }
            else
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");

            return View("~/Views/Media/LoginAccountView.cshtml", model);
        }

        [HttpGet]
        public IActionResult Authenticate()
        {
            return View("~/Views/Media/LoginAccountView.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            if (ModelState.IsValid)
            {
                var user = new AuthenticateResponse();

                try
                {
                    user = await _accountService.Authenticate(model);
                    await Authenticate(user);
                    return RedirectToAction("~/Views/Media/LoginAccountView.cshtml");
                }
                catch (AppException)
                {
                    ModelState.AddModelError("", "The username or password is incorrect");
                }
            }
            return View("~/Views/Media/LoginAccountView.cshtml", model);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View("~/Views/Media/LoginAccountView.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _accountService.ChangePassword(model);
                    return View("~/Views/Media/LoginAccountView.cshtml");
                }
                catch (AppException)
                {
                    ModelState.AddModelError("", "The username or password is incorrect");
                }
            }
            return View(model);
        }


        private async Task Authenticate(RegisterResponse user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        private async Task Authenticate(AuthenticateResponse user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
