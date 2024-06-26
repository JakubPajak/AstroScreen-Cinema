﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class Account
	{
        [Key]
        public Guid Account_ID { get; set; }


		public string Name { get; set; }


		public string Surname { get; set; }


		public string Email { get; set; }


		public bool IsRegistered { get; set; }


		public string Password { get; set; }


		public DateTime Birthdate { get; set; }


		public int PhoneNum { get; set; }


		//	//	Connection between different entities	//	//


		public List<Reservation>? Reservations { get; set; } = new List<Reservation>();
	}
}

