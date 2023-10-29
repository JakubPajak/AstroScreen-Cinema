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
                .RuleFor(a => a.PhoneNum, f => f.Random.Long(111111111, 999999999));

            return AccountGenerator.Generate(count);
        }



        public List<Actors> GenerateActors(int count)
        {
            var ActorsGenerator = new Faker<Actors>()       //Actors

                //.RuleFor(a => a.Actor_ID, f => f.IndexFaker)
                .RuleFor(a => a.FullName, f => f.Person.FullName);

            return ActorsGenerator.Generate(count);
        }



        public List<Categories> GenerateCategories(int count)
        {
            var CategoryGenerator = new Faker<Categories>()     //Category

                //.RuleFor(c => c.Categorie_ID, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Random.Word())
                .RuleFor(c => c.Description, f => f.Lorem.Sentences(4));

            return CategoryGenerator.Generate(count);
        }



        public List<CinemaHall> GenerateHall(int count, List<Movie> movies)
        {
            var HallGenerator = new Faker<CinemaHall>()     //Hall

                //.RuleFor(s => s.Hall_ID, f => f.IndexFaker)
                .RuleFor(s => s.NumOfSeats, f => f.Random.Int(100, 200))
                .RuleFor(s => s.RowNum, f => f.Random.Int(10, 20))   //RowNum
                .RuleFor(s => s.SeatNum, f => f.Random.Int(100, 200))  //SeatNum
                .RuleFor(s => s.City, f => f.Address.City())
                .RuleFor(s => s.Movie_ID, f => f.Random.Number(1, movies.Count));    //MovieID

            return HallGenerator.Generate(count);
        }



        public List<Customer> GenerateCustomer(int count, List<Reservation> reservations)
        {
            var CustomerGenerator = new Faker<Customer>()   //Customer
                //.RuleFor(c => c.Customer_ID, f => f.IndexFaker)
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Name, c.Surname))
                .RuleFor(c => c.Name, f => f.Person.FirstName)
                .RuleFor(c => c.Surname, f => f.Person.LastName)
                .RuleFor(c => c.Birthdate, f => f.Person.DateOfBirth)
                .RuleFor(c => c.PhoneNum, f => f.Random.Long(111111111, 999999999))
                .RuleFor(c => c.Reservation_ID, f => f.Random.Number(1, reservations.Count));  //Reservation_ID

            return CustomerGenerator.Generate(count);
        }



        public List<Directors> GenerateDirectors(int count)
        {
            var DirectorGenerator = new Faker<Directors>()      //Director

                //.RuleFor(d => d.Director_ID, f => f.IndexFaker)
                .RuleFor(d => d.FullName, f => f.Person.FullName);

            return DirectorGenerator.Generate(count);
        }



        public List<Movie> GenerateMovie(int count, List<Directors> directors, List<Showtime> showtimes)
        {
            var MovieGenerator = new Faker<Movie>()     //Movie

                //.RuleFor(m => m.Film_ID, f => f.IndexFaker)
                .RuleFor(m => m.Title, f => f.Random.Word())
                .RuleFor(m => m.Description, f => f.Random.Word())
                .RuleFor(m => m.Duration, f => f.Random.Int(90, 200))
                .RuleFor(m => m.Director_ID, f => f.Random.Number(1, directors.Count))
                .RuleFor(m => m.Showtime_ID, f => f.Random.Number(1, showtimes.Count));

            return MovieGenerator.Generate(count);
        }



        public List<Reservation> GenerateReservation(int count, List<Customer> customers,
            List<Account> accounts, List<Seats> seats, List<Showtime> showtimes)
        {
            var ReservationGenerator = new Faker<Reservation>()     //Reservations

            //.RuleFor(r => r.Reservation_ID, f => f.IndexFaker)
            .RuleFor(r => r.Reservation_date, f => f.Person.DateOfBirth)    // <-- Inny format daty nie chcial dzialac
            .RuleFor(r => r.Customer_ID, f => f.Random.Number(1, customers.Count))     //CustomerID
            .RuleFor(r => r.Account_ID, f => f.Random.Number(1, accounts.Count))      //AccountID   
            .RuleFor(r => r.Seat_ID, f => f.Random.Number(1, seats.Count))     //SeatID   
            .RuleFor(r => r.Showtime_ID, f => f.Random.Number(1, showtimes.Count));    //HallID

            return ReservationGenerator.Generate(count);
        }



        public List<Seats> GenerateSeats(int count, List<CinemaHall> halls, List<Reservation> reservations)
        {
            var SeatsGenerator = new Faker<Seats>()     //Seats

                //.RuleFor(s => s.Seat_ID, f => f.IndexFaker)
                .RuleFor(s => s.RowNum, f => f.Random.Int(10, 20))
                .RuleFor(s => s.SeatNum, f => f.Random.Int(100, 200))
                .RuleFor(s => s.IsReserved, f => f.Random.Bool())
                .RuleFor(s => s.Hall_ID, f => f.Random.Number(1, halls.Count))  // Hall_ID
                .RuleFor(s => s.Reservation_ID, f => f.Random.Number(1, reservations.Count));     // Reservation_ID

            return SeatsGenerator.Generate(count);
        }



        public List<Showtime> GenerateShowtime(int count, List<CinemaHall> halls)
        {
            var ShowTimeGenerator = new Faker<Showtime>()   //Showtime

                //.RuleFor(st => st.Showtime_ID, f => f.IndexFaker)
                .RuleFor(st => st.Hall_ID, f => f.Random.Number(1, halls.Count))   //HallID
                .RuleFor(st => st.Day, f => f.Date.Recent())
                .RuleFor(st => st.Time, f => f.Date.Recent());

            return ShowTimeGenerator.Generate(count);
        }



        public List<ActorsInMovies> GenerateActorsInMovie(int count, List<Actors> actors, List<Movie> movies)
        {
            var ActorsInMovieGenerator = new Faker<ActorsInMovies>()    //ActorsinMovie

                //.RuleFor(am => am.ActorsFilms_ID, f => f.IndexFaker)
                .RuleFor(am => am.Actor_ID, f => f.Random.Number(1, actors.Count))
                .RuleFor(am => am.Movie_ID, f => f.Random.Number(1, movies.Count));

            return ActorsInMovieGenerator.Generate(count);
        }



        public List<CategoriesAndMovies> GenerateCategoriesAndMovies(int count, List<Categories> categories, List<Movie> movies)
        {
            var CategoryMovieGenerator = new Faker<CategoriesAndMovies>()       //CategoryMovie

                //.RuleFor(cm => cm.CategoriesAndFilms_ID, f => f.IndexFaker)
                .RuleFor(cm => cm.Movie_ID, f => f.Random.Number(1, movies.Count))
                .RuleFor(cm => cm.Category_ID, f => f.Random.Number(1, categories.Count));

            return CategoryMovieGenerator.Generate(count);
        }
    }
}

