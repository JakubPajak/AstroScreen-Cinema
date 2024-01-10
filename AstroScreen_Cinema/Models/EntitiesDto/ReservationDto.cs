using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models.EntitiesDto
{
	public class ReservationDto : MyAccountDto
	{
        public DateTime Reservation_date { get; set; }


        public List<Seats> Seats { get; set; } = new List<Seats>();


        public Showtime Showtime { get; set; }

        public Account Account { get; set; }

        public Movie? Movie { get; set; }
    }
}

