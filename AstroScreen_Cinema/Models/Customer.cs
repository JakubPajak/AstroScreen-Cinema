using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class Customer
	{
		[Key]
		public int Customer_ID { get; set; }

		[EmailAddress]
		public string Email { get; set; }

        [Phone]
        public int PhoneNum { get; set; }


		public string Name { get; set; }


		public string Surname { get; set; }


		public DateTime Birthdate { get; set; }


        //	//	Connection between different entities	//	//


        public int Reservation_ID { get; set; }


		public Reservation Reservation { get; set; }
	}
}

