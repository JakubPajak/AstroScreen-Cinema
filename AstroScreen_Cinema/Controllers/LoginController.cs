using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using AstroScreen_Cinema.Models;
using AstroScreen_Cinema.Models.EntitiesDto;
using AstroScreen_Cinema.Services;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AstroScreen_Cinema.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDBContext _appDbContext;
        private readonly ILoginService _loginService;

        public LoginController(AppDBContext appDbContext, ILoginService loginService)
        {
            _appDbContext = appDbContext;
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var loginStatus = HttpContext.Session.GetString("LoginStatus") ?? "NULL";
            ViewBag.LoginStatus = loginStatus;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = _loginService.GetLogin(loginDto.Login, loginDto.Password, out string _token, out string _errorMessage);

            #region
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //using (var httpClient = new HttpClient())
            //{
            //    // Set the authorization header
            //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //    // Make your API request
            //    HttpResponseMessage response = await httpClient.GetAsync("Home/Index");

            //    // Check the response status
            //    if (response.IsSuccessStatusCode)
            //    {
            //        // Read the response content
            //        string responseBody = await response.Content.ReadAsStringAsync();
            //        // Process the response as needed
            //    }
            //    else
            //    {
            //        // Handle the error
            //    }
            //}
            #endregion

            if (user.Login != null)
            {
                HttpContext.Session.SetString("LoginStatus", user.IsLogged);
                HttpContext.Session.SetString("UserLogin", user.Login);
            }


            if (_errorMessage != "")
            {
                ViewBag.ErrorMessage = _errorMessage;
                return View(user);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            var loginStatus = HttpContext.Session.GetString("LoginStatus") ?? "NULL";

            ViewBag.LoginStatus = loginStatus;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            await _loginService.RegisterUser(registerDto);

            ViewBag.RegisterStatus = "DONE";
            return RedirectToAction("RegistrationConfirmation", "Login");
        }

        [Route("Registration-confirmation")]
        public IActionResult RegistrationConfirmation()
        {
            return View();
        }
    }
}

