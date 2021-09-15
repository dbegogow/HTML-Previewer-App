﻿using System;
using System.Diagnostics;
using HTMLPreviewerApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HTMLPreviewerApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
            =>  View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
