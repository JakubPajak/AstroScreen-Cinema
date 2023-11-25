using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AstroScreen_Cinema.Models;
using System;
using Microsoft.EntityFrameworkCore;


namespace AstroScreen_Cinema.Controllers
{
    public class NowShowingController : Controller
    {
        private readonly AppDBContext _context;
        public NowShowingController(AppDBContext context)
        {
            _context = context;
        }
        //public IActionResult Nowshowing()
        //{
        //    return View();
        //}
        public IActionResult Nowshowing()
        {
            // Pobierz dostępne miasta z bazy danych
            var cities = _context.CinemaHalls.Select(m => m.City).Distinct().ToList();
            ViewBag.Cities = cities;

            return View();
        }
        [HttpPost]
        public IActionResult GetMovieSchedule(string selectedCity)
        {
            // Pobierz harmonogram filmów dla wybranego miasta
            var movieSchedules = _context.CinemaHalls
                .Where(m => m.City == selectedCity)
                .ToList();

            return PartialView("_MovieSchedulePartial", movieSchedules);
        }
    }
}
