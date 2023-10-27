using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class ActorsInMovies
	{
        [Key]
        public int ActorsFilms_ID { get; set; }


		public int Actor_ID { get; set; }


		public Actors Actor { get; set; }


		public int Movie_ID { get; set; }


		public Movie Movie { get; set; }
	}
}

