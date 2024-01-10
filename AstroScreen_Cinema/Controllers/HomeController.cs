using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AstroScreen_Cinema.Models;
using System;
using AstroScreen_Cinema.Models.EntitiesDto;
using AstroScreen_Cinema.Services;
using Serilog;

namespace AstroScreen_Cinema.Controllers;

public class HomeController : Controller
{
    private readonly AppDBContext _appDbContext;
    private readonly IHomeService _homeService;

    public HomeController(AppDBContext appDbContext, IHomeService homeService)
    {
        _appDbContext = appDbContext;
        _homeService = homeService;
    }

    public async Task<IActionResult> Index()
    {
        //List<Movie> movies = _appDbContext.Movies.Where(m => m.Duration < 100).ToList();
        var loginStatus = HttpContext.Session.GetString("LoginStatus") ?? "NO";

        ViewBag.LoginStatus = loginStatus;

        var movies = await _homeService.GetMovies();
        return View(movies);
    }

    public IActionResult Privacy()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

