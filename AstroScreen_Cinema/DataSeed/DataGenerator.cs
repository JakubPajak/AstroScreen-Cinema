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
            //int count = 100;


            var DirectorGenerator = new Faker<Directors>()      
                .RuleFor(d => d.FullName, f => f.Person.FullName);


            var ActorsGenerator = new Faker<Actors>()       
                .RuleFor(a => a.FullName, f => f.Person.FullName);


            var MovieGenerator = new Faker<Movie>()
                .RuleFor(m => m.Title, f => f.Random.Word())
                .RuleFor(m => m.Description, f => f.Random.Word())
                .RuleFor(m => m.Duration, f => f.Random.Int(90, 200))
                .RuleFor(m => m.Director, f => DirectorGenerator.Generate());


             var HallGenerator = new Faker<CinemaHall>()
                .RuleFor(s => s.NumOfSeats, f => f.Random.Int(100, 200))
                .RuleFor(s => s.RowNum, f => f.Random.Int(10, 20))   //RowNum
                .RuleFor(s => s.SeatNum, f => f.Random.Int(100, 200))  //SeatNum
                .RuleFor(s => s.City, f => f.Address.City());


            // Poprawka wymagana
            //Movie dodane i dziala razem z direvtory
            var ShowTimeGenerator = new Faker<Showtime>()
                .RuleFor(st => st.Day, f => f.Date.Recent())
                .RuleFor(st => st.Time, f => f.Date.Recent())
                .RuleFor(s => s.CinemaHall, f => HallGenerator.Generate())
                .RuleFor(s => s.Movie, f => MovieGenerator.Generate());



             var AccountGenerator = new Faker<Account>()
                .RuleFor(a => a.Name, f => f.Person.FirstName)
                .RuleFor(a => a.Surname, f => f.Person.LastName)
                .RuleFor(a => a.Email, f => f.Person.Email)
                .RuleFor(a => a.Password, f => f.Random.Word())
                .RuleFor(a => a.Birthdate, f => f.Person.DateOfBirth)
                .RuleFor(a => a.PhoneNum, f => f.Random.Number(111111111, 999999999));



              var CategoryGenerator = new Faker<Categories>() 
                .RuleFor(c => c.Name, f => f.Random.Word())
                .RuleFor(c => c.Description, f => f.Lorem.Sentences(4));


              var SeatsGenerator = new Faker<Seats>()  
                .RuleFor(s => s.RowNum, f => f.Random.Int(10, 20))
                .RuleFor(s => s.SeatNum, f => f.Random.Int(100, 200))
                .RuleFor(s => s.IsReserved, f => f.Random.Bool())
                .RuleFor(s => s.CinemaHall, f => HallGenerator.Generate());   


              var ReservationGenerator = new Faker<Reservation>()     
                .RuleFor(r => r.Reservation_date, f => f.Person.DateOfBirth)    
                .RuleFor(r => r.Name, f => f.Person.FirstName)
                .RuleFor(r => r.Surname, f => f.Person.LastName)
                .RuleFor(r => r.Email, f => f.Person.Email)
                .RuleFor(r => r.PhoneNum, f => f.Random.Number(111111111, 999999999))
                .RuleFor(r => r.Seat, f => SeatsGenerator.Generate())
                .RuleFor(r => r.Showtime, f => ShowTimeGenerator.Generate())
                .RuleFor(r => r.Account, f => AccountGenerator.Generate());




            var ActorsInMovieGenerator = new Faker<ActorsInMovies>()    //ActorsinMovie
             .RuleFor(a => a.Actor, f => ActorsGenerator.Generate())
             .RuleFor(a => a.Movie, f => MovieGenerator.Generate());


            var CategoryMovieGenerator = new Faker<CategoriesAndMovies>()       //CategoryMovie
              .RuleFor(c => c.Categories, f => CategoryGenerator.Generate())
              .RuleFor(c => c.Movies, f => MovieGenerator.Generate());


            var movie = MovieGenerator.Generate(10);
            var director = DirectorGenerator.Generate(3);

            var actors = AccountGenerator.Generate(30);

            var showtime = ShowTimeGenerator.Generate(30);

            var hall = HallGenerator.Generate(10);
            var seat = SeatsGenerator.Generate(100);
            var account = AccountGenerator.Generate(30);

            var actorsmovie = ActorsInMovieGenerator.Generate(10);
            var category = CategoryGenerator.Generate(10);
            var categorymovie = CategoryMovieGenerator.Generate(30);
            var reservations = ReservationGenerator.Generate(100);

            _appContext.Movies.AddRange(movie);
            _appContext.Directors.AddRange(director);
          
           

            _appContext.Accounts.AddRange(account);
            
            _appContext.Seats.AddRange(seat);
            
            _appContext.Showtimes.AddRange(showtime);
            _appContext.Reservations.AddRange(reservations);
            
            _appContext.CinemaHalls.AddRange(hall);
            //_appContext.CinemaHalls.AddRange(actors);

  
            _appContext.ActorsInMovies.AddRange(actorsmovie);
            _appContext.Categories.AddRange(category);
            _appContext.CategoriesAndMovies.AddRange(categorymovie);
            //_appContext.SaveChanges();
        }

    }
    
}