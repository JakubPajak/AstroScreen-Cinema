using System;
using AstroScreen_Cinema.Models;
using AstroScreen_Cinema.Models.EntitiesDto;

namespace AstroScreen_Cinema.Services
{
	public class HallReperuairService
	{
        private readonly AppDBContext _appDBContext;

        public HallReperuairService(AppDBContext appDBContext)
		{
			_appDBContext = appDBContext;
		}

		public List<RepertoireDto> GetRepertoires(DateTime date)
		{
			var repertoires = _appDBContext.Showtimes.Where(sh => sh.Day.Equals(date.Day))
				.Join(_appDBContext.Movies,
				showtime => showtime.Movie_ID,
				movie => movie.Film_ID,
                (showtime, movie) => new RepertoireDto
				{
					MovieName = movie.Title,
					Desc = movie.Description,
                    Duration = movie.Duration,
                    Date = showtime.Day,
				}).ToList();
			
			return repertoires.Count() != 0 ? repertoires : new List<RepertoireDto>() { };
		}
	}
}

