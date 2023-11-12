using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AstroScreen_Cinema.Models;
using System;

namespace AstroScreen_Cinema.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDBContext _appDbContext;

    public HomeController(ILogger<HomeController> logger, AppDBContext appDbContext)
    {
        _logger = logger;
        _appDbContext = appDbContext;
    }

    public IActionResult Index()
    {
       List<Movie> movies = _appDbContext.Movies.Where(m => m.Duration < 100).ToList();
        return View(movies);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult NowShowing()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

