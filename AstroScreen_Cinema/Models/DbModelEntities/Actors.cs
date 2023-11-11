
using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class Actors
	{
        [Key]
        public Guid Actor_ID { get; set; }


		public string FullName { get; set; }


		public List<ActorsInMovies> Movies { get; set; } = new List<ActorsInMovies>();
	}
}

