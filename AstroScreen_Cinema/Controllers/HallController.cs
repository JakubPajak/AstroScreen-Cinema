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

        public IActionResult Hall_One(string selectedSchedule)
        {
            if (!string.IsNullOrEmpty(selectedSchedule))
            {
                var elements = selectedSchedule.Split(',').ToArray();
                HttpContext.Session.SetString("ShowtimeId", elements[1]);
            }
            else
            {
                //var elements = HttpContext.Session.GetString("SelectedSeats").Split(',').ToArray();
                ViewBag.Submitted = true;
            }
            var _city = HttpContext.Session.GetString("City");
            var hall = _hallRepertuair.GetHall(_city);
            return View(hall);
        }
    }
}
