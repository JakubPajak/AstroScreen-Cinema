using System;
namespace AstroScreen_Cinema.Models.EntitiesDto
{
	public class ViewHistory
	{
        public string Title { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public Guid ShowtimeId { get; set; }

        public Guid ReservationId { get; set; }

        public string ImagePath { get; set; }
    }
}

