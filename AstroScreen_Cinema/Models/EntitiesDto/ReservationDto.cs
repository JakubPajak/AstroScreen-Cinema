using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models.EntitiesDto
{
	public class ReservationDto : MyAccountDto
	{
        public DateTime Reservation_date { get; set; }


        public DateTime Birthdate { get; set; }


        public bool IsRegistered { get; set; }


        public Seats Seat { get; set; }


        public Showtime Showtime { get; set; }


        public Account? Account { get; set; }
    }
}

