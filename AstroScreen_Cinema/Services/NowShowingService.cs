﻿using System;
using System.Linq;
using AstroScreen_Cinema.Models;
using AstroScreen_Cinema.Models.EntitiesDto;

namespace AstroScreen_Cinema.Services
{
    public class NowShowingService : INowShowingService
    {
        private readonly AppDBContext _appDBContext;

        public NowShowingService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public List<RepertoireDto> GetRepertoires(DateTime date, string _city)
        {
            var hall = _appDBContext.CinemaHalls.FirstOrDefault(c => c.City.Equals(_city));

            var repertoires = _appDBContext.Showtimes
                .Where(sh => sh.Day.Date == date.Date && sh.Hall_ID.Equals(hall.Hall_ID))
                .Join(_appDBContext.Movies,
                    showtime => showtime.Movie_ID,
                    movie => movie.Film_ID,
                    (showtime, movie) => new RepertoireDto
                    {
                        MovieName = movie.Title,
                        ShowtimeId = showtime.Showtime_ID,
                        Desc = movie.Description,
                        Duration = movie.Duration,
                        Hour = showtime.Time.TimeOfDay,
                        imgPath = movie.PosterPath,
                        City = _city,
                    }).ToList();


            return GetUniqueMoviesWithHours(repertoires, _city);
        }

        public List<RepertoireDto> GetUniqueMoviesWithHours(List<RepertoireDto> repertoires, string _city)
        {
            var uniqueMovies = repertoires
                .GroupBy(movie => movie.MovieName)
                .Select(group => new RepertoireDto
                {
                    MovieName = group.Key,
                    City = group.First().City,
                    Desc = group.First().Desc,
                    Duration = group.First().Duration,
                    Hours = group.Select(movie => movie.Hour.ToString()).ToList(),
                    imgPath = group.First().imgPath,
                    Showtimes = group.Select(movie => movie.ShowtimeId).ToList(),
                })
                .ToList();

            return uniqueMovies;
        }

    }
}

