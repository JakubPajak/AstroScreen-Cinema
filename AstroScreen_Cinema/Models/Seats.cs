using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class Seats
	{
        [Key]
        public int Seat_ID { get; set; }


		public int RowNum { get; set; }


		public int SeatNum { get; set; }


		public bool IsReserved { get; set; }


        public int Hall_ID { get; set; }


		public CinemaHall? CinemaHall { get; set; }


		public List<Reservation>? Reservations { get; set; }

	}
}

