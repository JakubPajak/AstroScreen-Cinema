using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class Showtime
	{
        [Key]
        public int Showtime_ID { get; set; }


		public DateTime Day { get; set; }


		public DateTime Time { get; set; }


        //	//	Connection between different entities	//	//


        public List<Reservation>? Reservations { get; set; }


		public int Hall_ID { get; set; }


		public CinemaHall CinemaHall { get; set; }


		public Movie Movie { get; set; }
	}
}

