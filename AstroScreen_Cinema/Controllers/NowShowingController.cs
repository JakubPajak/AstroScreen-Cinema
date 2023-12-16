using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AstroScreen_Cinema.Models;
using System;
using Microsoft.EntityFrameworkCore;
using AstroScreen_Cinema.Services;
using AstroScreen_Cinema.Models.EntitiesDto;

namespace AstroScreen_Cinema.Controllers
{
    public class NowShowingController : Controller
    {
        private readonly INowShowingService _nowShowingService;

        public NowShowingController(INowShowingService nowShowingService)
        {
            _nowShowingService = nowShowingService;
        }
        //public IActionResult Nowshowing()
        //{
        //    return View();
        //}
        public IActionResult NowShowing()
        {
            if (Request.Method == "POST")
            {
                if (DateTime.TryParse(Request.Form["date"], out DateTime selectedDate) &&
                    Request.Form.TryGetValue("City", out var _city))
                {
                    var repertoires = _nowShowingService.GetRepertoires(selectedDate, _city);
                    HttpContext.Session.SetString("City", _city);
                    return View(repertoires);
                }
                else
                {
                    return BadRequest("Invalid Date format");
                }
            }

            return View(new List<RepertoireDto>() { });
        }
    }
}
