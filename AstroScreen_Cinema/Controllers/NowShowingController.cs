using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AstroScreen_Cinema.Models;
using System;


namespace AstroScreen_Cinema.Controllers
{
    public class NowShowingController : Controller
    {
        public IActionResult Nowshowing()
        {
            return View();
        }
    }
}
