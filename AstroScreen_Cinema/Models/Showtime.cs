using System;
namespace AstroScreen_Cinema.Models
{
	public class Showtime
	{
		public int Showtime_ID { get; set; }


		public DateOnly Day { get; set; }


		public TimeOnly Time { get; set; }


        //	//	Connection between different entities	//	//


        public List<Reservation> Reservations { get; set; }


		public int Hall_ID { get; set; }


		public CinemaHall CinemaHall { get; set; }


        public int Movie_ID { get; set; }


		public Movie Movie { get; set; }
	}
}

