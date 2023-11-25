using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AstroScreen_Cinema.Models;
using System;

namespace AstroScreen_Cinema.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Reservations()
        {
            return View();
        }
    }
}
