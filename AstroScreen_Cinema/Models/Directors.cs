
using System;
namespace AstroScreen_Cinema.Models
{
	public class Directors
	{
		public int Director_ID { get; set; }


		public string FullName { get; set; }


        //	//	Connection between different entities	//	//


        public List<Movie> Movies { get; set; }
	}
}

