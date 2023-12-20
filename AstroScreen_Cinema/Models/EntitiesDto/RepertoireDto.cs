using System;
namespace AstroScreen_Cinema.Models.EntitiesDto
{
	public class RepertoireDto
	{
		public string? MovieName { get; set; }

		public Guid ShowtimeId { get; set; }

		public TimeSpan? Hour { get; set; }

		public List<string>? Hours { get; set; }

        public List<Guid>? Showtimes { get; set; }

        public string? Desc { get; set; }

		public int? Duration { get; set; }

		public string City { get; set; }

		public string imgPath { get; set; }		
	}
}

