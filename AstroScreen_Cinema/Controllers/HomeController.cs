using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AstroScreen_Cinema.Models;
using System;
using AstroScreen_Cinema.Models.EntitiesDto;

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
        var activeUser = new LoginDto();
        //List<Movie> movies = _appDbContext.Movies.Where(m => m.Duration < 100).ToList();
        var loginStatus = HttpContext.Session.GetString("LoginStatus") ?? "NO";

        

        if (loginStatus is not null)
        {
            activeUser.IsLogged = loginStatus;
            activeUser.Login = "anonymous";
            activeUser.Password = "anonymous";
        }
        else
        {
            activeUser.IsLogged = loginStatus;
            activeUser.Login = "anonymous";
            activeUser.Password = "anonymous";
        }

        //ViewBag["LoginStatus", loginStatus];

        return View(activeUser);
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

