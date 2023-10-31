using AstroScreen_Cinema.Models;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using AstroScreen_Cinema.DataSeed;

namespace AstroScreen_Cinema
{
    public class DataGenerator
    {
        public readonly AppDBContext _appContext;
        private readonly DataSeeding _dataSeeding;

        public DataGenerator(AppDBContext appContext, DataSeeding dataSeeding)
        {
            _appContext = appContext;
            _dataSeeding = dataSeeding;
        }

        public void Seed()
        {
            Randomizer.Seed = new Random(123);
            int count = 100;



                var director = _dataSeeding.GenerateDirectors(count);
                var actors = _dataSeeding.GenerateActors(count);

                var showtime = _dataSeeding.GenerateShowtime(count);
                var movie = _dataSeeding.GenerateMovie(count);
                var hall = _dataSeeding.GenerateHall(count);
                var seat = _dataSeeding.GenerateSeats(count);
                var account = _dataSeeding.GenerateAccount(count);

                var actorsmovie = _dataSeeding.GenerateActorsInMovie(count);
                var category = _dataSeeding.GenerateCategories(count);
                var categorymovie = _dataSeeding.GenerateCategoriesAndMovies(count);
                var reservations = _dataSeeding.GenerateReservation(count);

                //_appContext.Accounts.AddRange(account);
                //_appContext.SaveChanges();

                _appContext.Reservations.AddRange(reservations);
                _appContext.Seats.AddRange(seat);
                _appContext.CinemaHalls.AddRange(hall);
                //_appContext.Actors.AddRange(actors);
            
            _appContext.Showtimes.AddRange(showtime);
            
            //_appContext.Directors.AddRange(director);
            _appContext.Movies.AddRange(movie);
            
            _appContext.ActorsInMovies.AddRange(actorsmovie);
            //_appContext.Categories.AddRange(category);
            _appContext.CategoriesAndMovies.AddRange(categorymovie);
            _appContext.SaveChanges();
        }

    }
    
}