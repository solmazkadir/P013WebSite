﻿using Microsoft.AspNetCore.Mvc;

namespace P013WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
