using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AstroScreen_Cinema.Models;
using System;
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

    public IActionResult Index()
    {
        _homeService.IndexTokens();
        return View();
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

