﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Controllers.Business
{
    [Authorize]
    public class BusinessController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
