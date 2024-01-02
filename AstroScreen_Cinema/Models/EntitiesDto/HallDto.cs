using System;
namespace AstroScreen_Cinema.Models.EntitiesDto
{
	public class HallDto
	{
		public string City { get; set; }

		public int NumberOfSeats { get; set; }

		public int NumberOfRows { get; set; }

		public List<SeatDto> SelectedSeats { get; set; }
	}
}

