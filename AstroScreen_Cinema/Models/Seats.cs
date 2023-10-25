using System;
namespace AstroScreen_Cinema.Models
{
	public class Seats
	{
		public int Seat_ID { get; set; }


		public int RowNum { get; set; }


		public int SeatNum { get; set; }


		public bool IsReserved { get; set; }


        public int Hall_ID { get; set; }


		public CinemaHall CinemaHall { get; set; }


		public int Reservation_ID { get; set; }


		public Reservation Reservation { get; set; }

	}
}

