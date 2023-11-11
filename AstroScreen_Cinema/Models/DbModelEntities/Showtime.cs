using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class Showtime
	{
        [Key]
        public Guid Showtime_ID { get; set; }


		public DateTime Day { get; set; }


		public DateTime Time { get; set; }


		//	//	Connection between different entities	//	//


		public List<Reservation>? Reservations { get; set; } = new List<Reservation>();


		public Guid Hall_ID { get; set; }


		public CinemaHall CinemaHall { get; set; }


		public Guid Movie_ID { get; set; }


		public Movie Movie { get; set; }
	}
}

