using AstroScreen_Cinema.Models;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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

        public void Seed(AppDBContext context)
        {
            Randomizer.Seed = new Random(123);

                      
            
            var account = _dataSeeding.GenerateAccount(100);                                              
            var movie = _dataSeeding.GenerateMovie(100, director, showtime);
            var hall = _dataSeeding.GenerateHall(100,movie); 
            var seat = _dataSeeding.GenerateSeats(100,hall, reservations);
            var showtime = _dataSeeding.GenerateShowtime(100,hall);            
            var actors = _dataSeeding.GenerateActors(100);       
            var actorsmovie = _dataSeeding.GenerateActorsInMovie(100,actors,movie);
            var category = _dataSeeding.GenerateCategories(100);     
            var categorymovie = _dataSeeding.GenerateCategoriesAndMovies(100,category,movie);
            var director = _dataSeeding.GenerateDirectors(100);
            var customers = _dataSeeding.GenerateCustomer(100, reservations);    // <-- czy dodawac reservationID?
            var reservations = _dataSeeding.GenerateReservation(100,customers,account,seat, showtime);


             context.Accounts.AddRange(account);
             context.Reservations.AddRange(reservations);
             context.Customers.AddRange(customers);
             context.Seats.AddRange(seat);
             context.CinemaHalls.AddRange(hall);
             context.Actors.AddRange(actors);
             context.Showtimes.AddRange(showtime);
             context.Movies.AddRange(movie);
             context.actorsInMovies.AddRange(actorsmovie);
             context.Categories.AddRange(category);
             context.Directors.AddRange(director);
             context.CategoriesAndMovies.AddRange(categorymovie);
        }

    }
    
}