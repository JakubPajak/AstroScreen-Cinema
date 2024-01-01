using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AstroScreen_Cinema.Models;
using System;
using AstroScreen_Cinema.Services;
using AstroScreen_Cinema.Models.EntitiesDto;

namespace AstroScreen_Cinema.Controllers
{
    [Route("Reservation")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly ILoginService _loginService;

        public ReservationController(IReservationService reservationService, ILoginService loginService)
        {
            _reservationService = reservationService;
            _loginService = loginService;
        }

        [Route("Choose-seats")]
        public IActionResult CacheSeatInformation()
        {
            string[] elements = Request.Form["selectedSeats"].ToString().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var seats = elements[elements.Count() - 2].Split(',').Skip(1).ToArray();
            var totalPrice = elements[elements.Count() - 1];

            _reservationService.CacheSeatInformation(seats, out string stringOfSeats);

            HttpContext.Session.SetString("SelectedSeats", stringOfSeats);
            HttpContext.Session.SetString("TotalPrice", totalPrice.ToString());

            return RedirectToAction("Hall_One", "Hall");
        }

        [Route("Proceed-to-checkout")]
        public IActionResult Reservations()
        { 
            var seats = HttpContext.Session.GetString("SelectedSeats").Split(',').ToArray();
            var totalPrice = HttpContext.Session.GetString("TotalPrice");

            var city = HttpContext.Session.GetString("City");
            var showtimeid = HttpContext.Session.GetString("ShowtimeId");


            //Additional information provided by the previous View such as the
            //total price of selected seats
            ViewBag.totalPrice = totalPrice;


            //The resason why the string containing seats, city and showtimeId is
            //used is that it secures chosen seats after selection but before
            //finalizing the transaction so that there would never occur
            //conflict.
            //After the seats are added other service will display taken seats


            //Get the user login to retrive user data
            //If the value is null then adequate fields will be empty
            var user = HttpContext.Session.GetString("UserLogin");

            //This service will send Model ReservationDto to the summarize page
            //in order to fulfill the reservation

            return View(_reservationService.GetReservationData(seats, showtimeid, city, user));
        }

        [HttpPost]
        [Route("Reservation-login")]
        public IActionResult LoginFromReservation(string _login, string _pass)
        {
            var user = _loginService.GetLogin(_login, _pass, out string _token);

            HttpContext.Session.SetString("LoginStatus", user.IsLogged);
            HttpContext.Session.SetString("UserLogin", user.Login);

            ViewBag.User = user.Login;

            return RedirectToAction("Reservations", "Reservation");
        }

        [HttpPost]
        [Route("Checkout")]
        public async Task<IActionResult> FulfillTheReservation(ReservationDto reservationDto)
        {
            var showtimeid = HttpContext.Session.GetString("ShowtimeId");

            var seats = HttpContext.Session.GetString("SelectedSeats").Split(',').ToArray();

            var user = HttpContext.Session.GetString("UserLogin");

            var city = HttpContext.Session.GetString("City");

            await _reservationService.SaveTheReservation(reservationDto, showtimeid, user, seats,city);

            return View();
        }
    }
}
