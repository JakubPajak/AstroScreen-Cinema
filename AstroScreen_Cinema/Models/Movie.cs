using System;
namespace AstroScreen_Cinema.Models
{
	public class Movie
	{
		public int Film_ID { get; set; }


		public string Title { get; set; }


		public string Description { get; set; }


		public int Duration { get; set; }


        //	//	Connection between different entities	//	//


        public int Director_ID { get; set; }


		public Directors Director { get; set; }


		public int Showtime_ID { get; set; }


		public Showtime Showtime { get; set; }
	}
}

