using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AstroScreen_Cinema.Models;
using System;
using AstroScreen_Cinema.Models.EntitiesDto;
using AstroScreen_Cinema.Services;

namespace AstroScreen_Cinema.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDBContext _appDbContext;
    private readonly HomeService _homeService;

    public HomeController(ILogger<HomeController> logger, AppDBContext appDbContext, HomeService homeService)
    {
        _logger = logger;
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

    //public async Task<IActionResult> NowShowing()
    //{

    //}


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

