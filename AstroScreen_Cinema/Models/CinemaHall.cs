using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class CinemaHall
	{
        [Key]
        public int Hall_ID { get; set; }


		public int NumOfSeats { get; set; }


		public int RowNum { get; set; }


		public int SeatNum { get; set; }


		public string City { get; set; }


		public List<Seats> Seats { get; set; }


		public List<Showtime> Showtimes { get; set; }
	}
}

