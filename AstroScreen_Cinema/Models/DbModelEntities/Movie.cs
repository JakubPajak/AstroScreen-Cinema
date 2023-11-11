using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class Movie
	{
        [Key]
        public Guid Film_ID { get; set; }


		public string Title { get; set; }


		public string Description { get; set; }


		public int Duration { get; set; }


        //	//	Connection between different entities	//	//


        public Guid Director_ID { get; set; }


		public Directors? Director { get; set; }


		public List<Showtime>? Showtimes { get; set; } = new List<Showtime>();


		public List<ActorsInMovies>? Actors { get; set; } = new List<ActorsInMovies>();

		public List<CategoriesAndMovies>? Categories { get; set; } = new List<CategoriesAndMovies>();
	}
}

