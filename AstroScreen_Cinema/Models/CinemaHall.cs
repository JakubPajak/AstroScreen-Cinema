using System;
namespace AstroScreen_Cinema.Models
{
	public class CinemaHall
	{
		public int Hall_ID { get; set; }


		public int NumOfSeats { get; set; }


		public int RowNum { get; set; }


		public int SeatNum { get; set; }


		public string City { get; set; }



        public int Movie_ID { get; set; }


		public Movie Movie { get; set; }


		public List<Seats> Seats { get; set; }


		public List<Showtime> Showtimes { get; set; }
	}
}

