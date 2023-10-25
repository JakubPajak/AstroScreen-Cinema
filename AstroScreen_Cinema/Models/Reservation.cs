using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class Reservation
	{
		public int Reservation_ID { get; set; }



		public int Customer_ID { get; set; }


		public Customer Customer { get; set; }


		public DateTime Reservation_date { get; set; }


		public int Seat_ID { get; set; }


		public Seats Seat { get; set; }


		public int Showtime_ID { get; set; }


		public Showtime Showtime { get; set; }


		public int Account_ID { get; set; }


		public Account Account { get; set; }
	}
}

