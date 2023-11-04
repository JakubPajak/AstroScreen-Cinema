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


            var DirectorGenerator = new Faker<Directors>()      //Director
                                                                //.RuleFor(d => d.Director_ID, f => f.IndexFaker)
                .RuleFor(d => d.FullName, f => f.Person.FullName);

                var ActorsGenerator = new Faker<Actors>()       //Actors                                              //.RuleFor(a => a.Actor_ID, f => f.IndexFaker)
                    .RuleFor(a => a.FullName, f => f.Person.FullName);


            var MovieGenerator = new Faker<Movie>()     //Movie

                //.RuleFor(m => m.Film_ID, f => f.IndexFaker)
                .RuleFor(m => m.Title, f => f.Random.Word())
                .RuleFor(m => m.Description, f => f.Random.Word())
                .RuleFor(m => m.Duration, f => f.Random.Int(90, 200))
                .RuleFor(m => m.Director, f => DirectorGenerator.Generate());




                var HallGenerator = new Faker<CinemaHall>()     //Hall

                    //.RuleFor(s => s.Hall_ID, f => f.IndexFaker)
                    .RuleFor(s => s.NumOfSeats, f => f.Random.Int(100, 200))
                    .RuleFor(s => s.RowNum, f => f.Random.Int(10, 20))   //RowNum
                    .RuleFor(s => s.SeatNum, f => f.Random.Int(100, 200))  //SeatNum
                    .RuleFor(s => s.City, f => f.Address.City());

            // Poprawka wymagana
            //Movie dodane i dziala razem z direvtory
            var ShowTimeGenerator = new Faker<Showtime>()   //Showtime

                //.RuleFor(st => st.Showtime_ID, f => f.IndexFaker)
                .RuleFor(st => st.Day, f => f.Date.Recent())
                .RuleFor(st => st.Time, f => f.Date.Recent())
                .RuleFor(s => s.CinemaHall, f => HallGenerator.Generate())
                .RuleFor(s => s.Movie, f => MovieGenerator.Generate());



                var AccountGenerator = new Faker<Account>()
                    //.RuleFor(a => a.Account_ID, f => f.IndexFaker)
                    .RuleFor(a => a.Name, f => f.Person.FirstName)
                    .RuleFor(a => a.Surname, f => f.Person.LastName)
                    .RuleFor(a => a.Email, f => f.Person.Email)
                    .RuleFor(a => a.Password, f => f.Random.Word())
                    .RuleFor(a => a.Birthdate, f => f.Person.DateOfBirth)
                    .RuleFor(a => a.PhoneNum, f => f.Random.Number(111111111, 999999999));



                var CategoryGenerator = new Faker<Categories>()     //Category
                    //.RuleFor(c => c.Categorie_ID, f => f.IndexFaker)
                    .RuleFor(c => c.Name, f => f.Random.Word())
                    .RuleFor(c => c.Description, f => f.Lorem.Sentences(4));



                var ReservationGenerator = new Faker<Reservation>()     //Reservations

                .RuleFor(r => r.Reservation_ID, f => f.IndexFaker)
                .RuleFor(r => r.Reservation_date, f => f.Person.DateOfBirth)    // <-- Inny format daty nie chcial dzialac
                .RuleFor(r => r.Account_ID, f => f.IndexFaker)      //AccountID   
                .RuleFor(r => r.Seat_ID, f => f.IndexFaker)     //SeatID   
                .RuleFor(r => r.Showtime_ID, f => f.IndexFaker)
                .RuleFor(r => r.Name, f => f.Person.FirstName)
                .RuleFor(r => r.Surname, f => f.Person.LastName)
                .RuleFor(r => r.Email, f => f.Person.Email)
                .RuleFor(r => r.PhoneNum, f => f.Random.Number(111111111, 999999999));    //HallID

                var SeatsGenerator = new Faker<Seats>()     //Seats

                    //.RuleFor(s => s.Seat_ID, f => f.IndexFaker)
                    .RuleFor(s => s.RowNum, f => f.Random.Int(10, 20))
                    .RuleFor(s => s.SeatNum, f => f.Random.Int(100, 200))
                    .RuleFor(s => s.IsReserved, f => f.Random.Bool())
                    .RuleFor(s => s.Hall_ID, f => f.IndexFaker);    // Reservation_ID




                var ActorsInMovieGenerator = new Faker<ActorsInMovies>()    //ActorsinMovie

                    .RuleFor(am => am.Actor_ID, f => f.IndexFaker)
                    .RuleFor(am => am.Movie_ID, f => f.IndexFaker);


                var CategoryMovieGenerator = new Faker<CategoriesAndMovies>()       //CategoryMovie

                    .RuleFor(cm => cm.Movie_ID, f => f.IndexFaker)
                    .RuleFor(cm => cm.Category_ID, f => f.IndexFaker);


            //var movie = MovieGenerator.Generate(3);
            //var director = DirectorGenerator.Generate(3);

            var actors = _dataSeeding.GenerateActors(count);

            var showtime = _dataSeeding.GenerateShowtime(count);

            var hall = _dataSeeding.GenerateHall(count);
            var seat = _dataSeeding.GenerateSeats(count);
            var account = _dataSeeding.GenerateAccount(count);

            var actorsmovie = _dataSeeding.GenerateActorsInMovie(count);
            var category = _dataSeeding.GenerateCategories(count);
            var categorymovie = _dataSeeding.GenerateCategoriesAndMovies(count);
            var reservations = _dataSeeding.GenerateReservation(count);

            //_appContext.Movies.AddRange(movie);
            //_appContext.Directors.AddRange(director);
          
            _appContext.SaveChanges();

            _appContext.Accounts.AddRange(account);
                //_appContext.SaveChanges();
                _appContext.Seats.AddRange(seat);
                _appContext.Showtimes.AddRange(showtime);
                _appContext.Reservations.AddRange(reservations);
            
                _appContext.CinemaHalls.AddRange(hall);
                _appContext.Actors.AddRange(actors);

            // Wyświetl dane wygenerowane w konsoli
            foreach (var reservation in reservations)
            {
                Console.WriteLine($"Reservation_ID: {reservation.Reservation_ID}, Reservation_date: {reservation.Reservation_date}, Account_ID: {reservation.Account_ID}, Seat_ID: {reservation.Seat_ID}, Showtime_ID: {reservation.Showtime_ID}, Name: {reservation.Name}, Surname: {reservation.Surname}, Email: {reservation.Email}, PhoneNum: {reservation.PhoneNum}");
            }

  
            _appContext.ActorsInMovies.AddRange(actorsmovie);
            _appContext.Categories.AddRange(category);
            _appContext.CategoriesAndMovies.AddRange(categorymovie);
            //_appContext.SaveChanges();
        }

    }
    
}