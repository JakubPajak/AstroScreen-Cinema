using System;
using AstroScreen_Cinema.Models;

namespace AstroScreen_Cinema.DataSeed
{
	public class MyShowtimeGen
	{
        private readonly AppDBContext _appContext;

        public MyShowtimeGen(AppDBContext appContext)
		{
			_appContext = appContext;
		}

		public List<Showtime> GenerateShowtime()
		{
			var myShowtimes = new List<Showtime>() { };
			//Do tej listy dodawaj wygenerowane showtimy
			//Reszta analigicznie jak w pliku MyMovieGen
			//Zwracasz listę z typem generycznym Showtime, do bazy tutaj nic nie dodajesz
			//ani nie zapisujesz


			return myShowtimes;
		}
	}
}

