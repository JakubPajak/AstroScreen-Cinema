using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AstroScreen_Cinema.Models;
using System;
using AstroScreen_Cinema.Services;

namespace AstroScreen_Cinema.Controllers
{
    public class HallController : Controller
    {
        private readonly IHallReperuairService _hallRepertuair;

        public HallController(IHallReperuairService hallRepertuair)
        {
            _hallRepertuair = hallRepertuair;
        }

        public IActionResult Hall_One()
        {
            var _city = HttpContext.Session.GetString("City");
            var hall = _hallRepertuair.GetHall(_city);
            return View(hall);
        }

        //private IActionResult View(object value)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
