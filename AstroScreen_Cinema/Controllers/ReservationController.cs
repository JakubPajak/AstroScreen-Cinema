using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AstroScreen_Cinema.Models;
using System;
using AstroScreen_Cinema.Services;

namespace AstroScreen_Cinema.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IActionResult Reservations()
        {
            var seats = Request.Form["selectedSeats"]
                .ToString()
                .Split(',')
                .Distinct()
                .ToArray();
            var city = HttpContext.Session.GetString("City");
            var showtimeid = HttpContext.Session.GetString("ShowtimeId");

            //The resason why the string containing seats, city and showtimeId is
            //used is that it secures chosen seats after selection but before
            //finalizing the transaction so that there would never occur
            //conflict.
            //After the seats are added other service will display taken seats
            var tempString = _reservationService.MakeReservationTemporary(seats, city, showtimeid);
            HttpContext.Session.SetString("TemporaryTakenSeats", tempString);

            //Get the user login to retrive user data
            //If the value is null then adequate fields will be empty
            var user = HttpContext.Session.GetString("UserLogin");

            //This service will send Model ReservationDto to the summarize page
            //in order to fulfill the reservation

            return View(_reservationService.GetReservationData(seats, showtimeid, city, user));
        }
    }
}
