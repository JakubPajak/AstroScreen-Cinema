using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AstroScreen_Cinema.Models
{
	public class Reservation
	{
        [Key]
        public Guid Reservation_ID { get; set; }


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

        public List<Seats> Seats { get; set; }


        public Guid Showtime_ID { get; set; }


		public Showtime? Showtime { get; set; }


		public Guid Account_ID { get; set; }


		public Account? Account { get; set; }
	}
}

