using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class CategoriesAndMovies
	{
        [Key]
        public int CategoriesAndFilms_ID { get; set; }


		public int Category_ID { get; set; }


		public Categories Categories { get; set; }


		public int Movie_ID { get; set; }


		public Movie Movies { get; set; }
	}
}

