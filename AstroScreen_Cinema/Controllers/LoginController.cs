using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AstroScreen_Cinema.Models;
using AstroScreen_Cinema.Models.EntitiesDto;
using AstroScreen_Cinema.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AstroScreen_Cinema.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly AppDBContext _appDbContext;
        private readonly LoginService _loginService;

        public LoginController(ILogger<LoginController> logger, AppDBContext appDbContext, LoginService loginService)
        {
            _logger = logger;
            _appDbContext = appDbContext;
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginDto loginDto)
        {
            var user = _loginService.GetLogin(loginDto.Login, loginDto.Password);

            HttpContext.Session.SetString("LoginStatus", user.IsLogged);
            HttpContext.Session.SetString("UserLogin", user.Login);
            return RedirectToAction("Index", "Home");
        }
    }
}

