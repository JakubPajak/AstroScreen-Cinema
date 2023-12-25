using System;
namespace AstroScreen_Cinema.Models.EntitiesDto
{
	public class MyAccountDto : Account
	{
		public Dictionary<string, ReservationDto> ReservationDetails { get; set; }
	}
}

