using System;
using AstroScreen_Cinema.Models.EntitiesDto;
using AstroScreen_Cinema.Services;
using Microsoft.AspNetCore.Mvc;

namespace AstroScreen_Cinema.Controllers
{
    public class MyAccountController : Controller
    {
        private readonly IMyAccountService _myAccountService;

        public MyAccountController(IMyAccountService myAccountService)
        {
            _myAccountService = myAccountService;
        }

        public IActionResult MyAccount()
        {
            var userLogin = HttpContext.Session.GetString("UserLogin");

            var accountData = _myAccountService.GetAccountData(userLogin);

            return View(accountData);
        }

        public IActionResult ChangeData()
        {
            var userLogin = HttpContext.Session.GetString("UserLogin");

            var accountData = _myAccountService.GetAccountData(userLogin);

            return RedirectToAction("MyAccount", "MyAccount", accountData);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeData(MyAccountDto myAccountDto)
        {
            await _myAccountService.ChangeDataService(myAccountDto);

            return RedirectToAction("MyAccount", "MyAccount");
        }

        public IActionResult ViewingHistory()
        {
            var _login = HttpContext.Session.GetString("UserLogin");

            var history = _myAccountService.GetViewingHistory(_login);

            return RedirectToAction("MyAccount", "MyAccount", history);
        }
    }
}