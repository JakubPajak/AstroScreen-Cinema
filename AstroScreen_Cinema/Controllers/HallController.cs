using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AstroScreen_Cinema.Models;
using System;
using AstroScreen_Cinema.Services;

namespace AstroScreen_Cinema.Controllers
{
    public class HallController : Controller
    {
        private readonly HallController _hallController;
        private readonly HallReperuairService _hallRepertuair;

        public HallController(HallReperuairService hallRepertuair)
        {
            _hallRepertuair = hallRepertuair;
        }

        [HttpPost]
        //public async Task<IActionResult> Hall_1(DateTime _date)
        //{
        //    return View(await _hallRepertuair.GetRepertoires(_date));
        //}

        private IActionResult View(object value)
        {
            throw new NotImplementedException();
        }
    }
}
