using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class ActorsInMovies
	{
		public int Actor_ID { get; set; }


		public Actors Actor { get; set; }


		public int Movie_ID { get; set; }


		public Movie Movie { get; set; }
	}
}

