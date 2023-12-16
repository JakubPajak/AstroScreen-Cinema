using System;
using AstroScreen_Cinema.Models;

namespace AstroScreen_Cinema.DataSeed
{
	public class MyHallGen
	{
		public MyHallGen()
		{ }

		public List<CinemaHall> GenerateCinemaHalls()
		{
			var halls = new List<CinemaHall>() { };
			var cities = new[] { "Gliwice", "Zabrze", "Warszawa", "Kraków" };

			foreach (var city in cities)
			{
				var hall = new CinemaHall
				{
					NumOfSeats = 150,
					RowNum = 10,
					SeatNum = 1,
					City = city,
				};
				halls.Add(hall);
			}

			return halls;
		}
	}
}

