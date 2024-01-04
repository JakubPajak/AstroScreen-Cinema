using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AstroScreen_Cinema.Models;
using System;
using AstroScreen_Cinema.Services;
using AstroScreen_Cinema.Models.EntitiesDto;

namespace AstroScreen_Cinema.Controllers
{
    public class HallController : Controller
    {
        private readonly IHallReperuairService _hallRepertuair;

        public HallController(IHallReperuairService hallRepertuair)
        {
            _hallRepertuair = hallRepertuair;
        }

        public IActionResult HallTemp(string selectedSchedule)
        {
            var elements = new string[' '];
            if (!string.IsNullOrEmpty(selectedSchedule))
            {
                elements = selectedSchedule.Split(',').ToArray();
                HttpContext.Session.SetString("ShowtimeId", elements[1]);
            }
            return RedirectToAction("Hall_One", "Hall");
        }

        public IActionResult Hall_One()
        {
            var elements = HttpContext.Session.GetString("ShowtimeId");
            var _city = HttpContext.Session.GetString("City");
            if (HttpContext.Session.GetString("Submitted") != null && HttpContext.Session.GetString("Submitted").Equals("Once"))
            {
                if (HttpContext.Session.GetString("LoginStatus") == null)
                    ViewBag.Submitted = true;
                else
                    ViewBag.Submitted = false;
            }

            var hall = _hallRepertuair.GetHall(_city, elements);
            return View(hall);
        }
    }
}
