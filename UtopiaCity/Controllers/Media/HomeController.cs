using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UtopiaCity.Controllers.Media
{
    public class MediaHomeController : Controller
    {
        public IActionResult Index()
        {
            var role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;

            if(role.ToLower() == "user")
            {
                return View("~/Views/Media/Index.cshtml");
            }

            if (role.ToLower() == "admin")
            {
                return View("~/Views/Media/Index.cshtml");

            }
            if (role.ToLower() == "author")
            {
                return View("~/Views/Media/Index.cshtml");

            }

            if (role.ToLower() == "editor")
            {
                return View("~/Views/Media/Index.cshtml");

            }

            if (role.ToLower() == "approver")
            {
                return View("~/Views/Media/Index.cshtml");

            }

            if (role.ToLower() == "advertiser")
            {
                return View("~/Views/Media/Index.cshtml");
            }

            return View("~/Views/Media/Index.cshtml");
        }
    }
}
