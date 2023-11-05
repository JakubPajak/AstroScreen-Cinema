using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class ActorsInMovies
	{
		public Guid Actor_ID { get; set; }


		public Actors Actor { get; set; }


		public Guid Movie_ID { get; set; }


		public Movie Movie { get; set; }
	}
}

