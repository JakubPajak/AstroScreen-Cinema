
using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class Actors
	{
        [Key]
        public int Actor_ID { get; set; }


		public string FullName { get; set; }


		public List<ActorsInMovies>? Movies { get; set; }
	}
}

