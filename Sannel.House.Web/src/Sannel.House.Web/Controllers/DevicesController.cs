﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sannel.House.Web.Base.Interfaces;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sannel.House.Web.Controllers
{
	[Authorize(Roles = "Admin,Controller")]
    public class DevicesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
			ViewBag.Section = "Devices";
            return View();
        }
    }
}
