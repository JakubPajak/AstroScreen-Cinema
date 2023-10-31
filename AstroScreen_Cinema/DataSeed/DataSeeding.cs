using System;
using AstroScreen_Cinema.Models;
using Bogus;

namespace AstroScreen_Cinema.DataSeed
{
	public class DataSeeding
	{
        
        public List<Account> GenerateAccount(int count)
        {
            var AccountGenerator = new Faker<Account>()
                //.RuleFor(a => a.Account_ID, f => f.IndexFaker)
                .RuleFor(a => a.Name, f => f.Person.FirstName)
                .RuleFor(a => a.Surname, f => f.Person.LastName)
                .RuleFor(a => a.Email, f => f.Person.Email)
                .RuleFor(a => a.Password, f => f.Random.Word())
                .RuleFor(a => a.Birthdate, f => f.Person.DateOfBirth)
                .RuleFor(a => a.PhoneNum, f => f.Random.Number(111111111, 999999999));

            return AccountGenerator.Generate(count);
            //return new List<Account>();

        }



        public List<Actors> GenerateActors(int count)
        {
            var ActorsGenerator = new Faker<Actors>()       //Actors
                //.RuleFor(a => a.Actor_ID, f => f.IndexFaker)
                .RuleFor(a => a.FullName, f => f.Person.FullName);

            return ActorsGenerator.Generate(count);
            //return new List<Actors>();
        }



        public List<Categories> GenerateCategories(int count)
        {
            var CategoryGenerator = new Faker<Categories>()     //Category

                //.RuleFor(c => c.Categorie_ID, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Random.Word())
                .RuleFor(c => c.Description, f => f.Lorem.Sentences(4));

            return CategoryGenerator.Generate(count);
            //return new List<Categories>();
        }



        public List<CinemaHall> GenerateHall(int count)
        {
            var HallGenerator = new Faker<CinemaHall>()     //Hall

                //.RuleFor(s => s.Hall_ID, f => f.IndexFaker)
                .RuleFor(s => s.NumOfSeats, f => f.Random.Int(100, 200))
                .RuleFor(s => s.RowNum, f => f.Random.Int(10, 20))   //RowNum
                .RuleFor(s => s.SeatNum, f => f.Random.Int(100, 200))  //SeatNum
                .RuleFor(s => s.City, f => f.Address.City());

            return HallGenerator.Generate(count);
            //return new List<CinemaHall>();
        }


        public List<Directors> GenerateDirectors(int count)
        {
            var DirectorGenerator = new Faker<Directors>()      //Director

                //.RuleFor(d => d.Director_ID, f => f.IndexFaker)
                .RuleFor(d => d.FullName, f => f.Person.FullName);

            return DirectorGenerator.Generate(count);
            //return new List<Directors>();
        }



        public List<Movie> GenerateMovie(int count)
        {
            var MovieGenerator = new Faker<Movie>()     //Movie

                //.RuleFor(m => m.Film_ID, f => f.IndexFaker)
                .RuleFor(m => m.Title, f => f.Random.Word())
                .RuleFor(m => m.Description, f => f.Random.Word())
                .RuleFor(m => m.Duration, f => f.Random.Int(90, 200))
                .RuleFor(m => m.Director_ID, f => f.IndexFaker)
                .RuleFor(m => m.Showtime_ID, f => f.IndexFaker);

            return MovieGenerator.Generate(count);
            //return new List<Movie>();
        }



        public List<Reservation> GenerateReservation(int count)
        {
            var ReservationGenerator = new Faker<Reservation>()     //Reservations

            //.RuleFor(r => r.Reservation_ID, f => f.IndexFaker)
            .RuleFor(r => r.Reservation_date, f => f.Person.DateOfBirth)    // <-- Inny format daty nie chcial dzialac
            .RuleFor(r => r.Account_ID, f => f.IndexFaker)      //AccountID   
            .RuleFor(r => r.Seat_ID, f => f.IndexFaker)     //SeatID   
            .RuleFor(r => r.Showtime_ID, f => f.IndexFaker)
            .RuleFor(r => r.Name, f => f.Person.FirstName)
            .RuleFor(r => r.Surname, f => f.Person.LastName)
            .RuleFor(r => r.Email, f => f.Person.Email)
            .RuleFor(r => r.PhoneNum, f => f.Random.Number(111111111, 999999999));    //HallID

            return ReservationGenerator.Generate(count);
            //return new List<Reservation>();
        }



        public List<Seats> GenerateSeats(int count)
        {
            var SeatsGenerator = new Faker<Seats>()     //Seats

                //.RuleFor(s => s.Seat_ID, f => f.IndexFaker)
                .RuleFor(s => s.RowNum, f => f.Random.Int(10, 20))
                .RuleFor(s => s.SeatNum, f => f.Random.Int(100, 200))
                .RuleFor(s => s.IsReserved, f => f.Random.Bool())
                .RuleFor(s => s.Hall_ID, f => f.IndexFaker);    // Reservation_ID

            return SeatsGenerator.Generate(count);
            //return new List<Seats>();
        }



        public List<Showtime> GenerateShowtime(int count)
        {
            var ShowTimeGenerator = new Faker<Showtime>()   //Showtime

                //.RuleFor(st => st.Showtime_ID, f => f.IndexFaker)
                .RuleFor(st => st.Hall_ID, f => f.IndexFaker)   //HallID
                .RuleFor(st => st.Day, f => f.Date.Recent())
                .RuleFor(st => st.Time, f => f.Date.Recent())
                .RuleFor(st => st.Movie_ID, f => f.IndexFaker);

            return ShowTimeGenerator.Generate(count);
            //return new List<Showtime>();
        }



        public List<ActorsInMovies> GenerateActorsInMovie(int count)
        {
            var ActorsInMovieGenerator = new Faker<ActorsInMovies>()    //ActorsinMovie

                .RuleFor(am => am.Actor_ID, f => f.IndexFaker)
                .RuleFor(am => am.Movie_ID, f => f.IndexFaker);

            return ActorsInMovieGenerator.Generate(count);
            //return new List<ActorsInMovies>();
        }



        public List<CategoriesAndMovies> GenerateCategoriesAndMovies(int count)
        {
            var CategoryMovieGenerator = new Faker<CategoriesAndMovies>()       //CategoryMovie

                .RuleFor(cm => cm.Movie_ID, f => f.IndexFaker)
                .RuleFor(cm => cm.Category_ID, f => f.IndexFaker);

            return CategoryMovieGenerator.Generate(count);

            //return new List<CategoriesAndMovies>();
        }
    }
}

