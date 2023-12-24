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

        public IActionResult CacheSeatInformation()
        {
            string[] elements = Request.Form["selectedSeats"].ToString().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var seats = elements[elements.Count() - 2].Split(',').Skip(1).ToArray();
            var totalPrice = elements[elements.Count() - 1];

            var city = HttpContext.Session.GetString("City");
            var showtimeid = HttpContext.Session.GetString("ShowtimeId");

            _reservationService.CacheSeatInformation(seats, out string stringOfSeats);

            HttpContext.Session.SetString("SelectedSeats", stringOfSeats);
            HttpContext.Session.SetString("TotalPrice", totalPrice.ToString());

            return RedirectToAction("Hall_One", "Hall");
        }


        public IActionResult Reservations()
        { 
            string[] elements = Request.Form["selectedSeats"].ToString().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var seats = elements[elements.Count() - 2].Split(',').Skip(1).ToArray();
            var totalPrice = elements[elements.Count()-1];

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
    }
}
