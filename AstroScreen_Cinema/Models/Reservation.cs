using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AstroScreen_Cinema.Models
{
	public class Reservation
	{
        [Key]
        public int Reservation_ID { get; set; }


		public DateTime Reservation_date { get; set; }


        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public int PhoneNum { get; set; }


        public string Name { get; set; }


        public string Surname { get; set; }


        public DateTime Birthdate { get; set; }


        public bool IsRegistered { get; set; }


        //	//	Connection between different entities	//	//


        public int Seat_ID { get; set; }


		public Seats Seat { get; set; }


		public int Showtime_ID { get; set; }


		public Showtime Showtime { get; set; }


		public int Account_ID { get; set; }


		public Account? Account { get; set; }
	}
}

