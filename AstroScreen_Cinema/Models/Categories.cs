
using System;
using System.ComponentModel.DataAnnotations;

namespace AstroScreen_Cinema.Models
{
	public class Categories
	{
        [Key]
        public Guid Categorie_ID { get; set; }


		public string Name { get; set; }


		public string Description { get; set; }


		public List<CategoriesAndMovies>? Movies { get; set; } = new List<CategoriesAndMovies>();
	}
}

