﻿
using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class Directors
	{
        [Key]
        public Guid Director_ID { get; set; }


		public string FullName { get; set; }


        //	//	Connection between different entities	//	//



        public List<Movie> Movies { get; set; } = new List<Movie>();
	}
}

