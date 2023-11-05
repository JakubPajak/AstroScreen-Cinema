using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class Seats
	{
        [Key]
        public Guid Seat_ID { get; set; }


		public int RowNum { get; set; }


		public int SeatNum { get; set; }


		public bool IsReserved { get; set; }


        public Guid Hall_ID { get; set; }


		public CinemaHall? CinemaHall { get; set; }


		public List<Reservation>? Reservations { get; set; } = new List<Reservation>();

	}
}

