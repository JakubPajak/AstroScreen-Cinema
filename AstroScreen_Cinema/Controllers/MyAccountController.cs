using System;
using Microsoft.AspNetCore.Mvc;

namespace AstroScreen_Cinema.Controllers
{
	public class MyAccountController : Controller
	{
		public MyAccountController()
		{
		}

		public IActionResult MyAccount()
		{
			return View();
		}
	}
}

