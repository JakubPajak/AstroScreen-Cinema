using AstroScreen_Cinema.Models;
using Bogus;


namespace AstroScreen_Cinema
{
    public class DataGenerator
    {

            public List<Reservation> GenerateReservation(int count, List<Customer> customers,List<Account> accounts, List<Seats> seats,List<CinemaHall> halls )
            {
                var ReservationGenerator = new Faker<Reservation>()     //Reservations

                .RuleFor(r => r.Reservation_ID, f => f.IndexFaker)
                .RuleFor(r => r.Reservation_date, f => f.Person.DateOfBirth)    // <-- Inny format daty nie chcial dzialac
                .RuleFor(r => r.Customer_ID, f => f.IndexFaker)     //CustomerID
                .RuleFor(r => r.Account_ID, f => f.IndexFaker)      //AccountID   
                .RuleFor(r => r.Seat_ID, f => f.IndexFaker)     //SeatID   
                .RuleFor(r => r.Showtime_ID, f => f.IndexFaker);    //HallID
            return ReservationGenerator.Generate(count);
            }//Reservation

            public List<Customer> GenerateCustomer(int count)
            {
            var CustomerGenerator = new Faker<Customer>()   //Customer
                .RuleFor(c => c.Customer_ID, f => f.IndexFaker)
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Name, c.Surname))
                .RuleFor(c => c.Birthdate, f => f.Person.DateOfBirth)
                .RuleFor(c => c.Surname, f => f.Person.LastName)
                .RuleFor(c => c.Name, f => f.Person.FirstName)
                .RuleFor(c => c.PhoneNum, f => f.Random.Long(111111111, 999999999))
                .RuleFor(c => c.Reservation_ID, f => f.IndexFaker);  //Reservation_ID
            return CustomerGenerator.Generate(count);
            }//Customer

            public List<Account> GenerateAccount(int count)
            {
            var AccountGenerator = new Faker<Account>()
                .RuleFor(a => a.Account_ID, f => f.IndexFaker)
                .RuleFor(a => a.Name, f => f.Person.FirstName)
                .RuleFor(a => a.Email, f => f.Person.Email)
                .RuleFor(a => a.Password, f => f.Random.Word())
                .RuleFor(a => a.Birthdate, f => f.Person.DateOfBirth)
                .RuleFor(a => a.PhoneNum, f => f.Random.Long(111111111, 999999999));
            return AccountGenerator.Generate(count);
            }//Account
            
            public List<Seats> GenerateSeats(int count, List<CinemaHall> halls)
            {
            var SeatsGenerator = new Faker<Seats>()     //Seats

                .RuleFor(s => s.Seat_ID, f => f.IndexFaker)
                .RuleFor(s => s.RowNum, f => f.Random.Int(10, 20))
                .RuleFor(s => s.SeatNum, f => f.Random.Int(100, 200))
                .RuleFor(s => s.IsReserved, f => f.Random.Bool())
                .RuleFor(s => s.Hall_ID, f => f.IndexFaker)  // Hall_ID
                .RuleFor(s => s.Reservation_ID, f => f.IndexFaker);     // Reservation_ID
            return SeatsGenerator.Generate(count);
            }//Seats

            public List<CinemaHall> GenerateHall(int count, List<Movie> Movie)
            {
            var HallGenerator = new Faker<CinemaHall>()     //Hall

                .RuleFor(s => s.Hall_ID, f => f.IndexFaker)
                .RuleFor(s => s.NumOfSeats, f => f.Random.Int(100, 200))
                .RuleFor(s => s.RowNum, f => f.Random.Int(10,20))   //RowNum
                .RuleFor(s => s.SeatNum, f => f.Random.Int(100,200))  //SeatNum
                .RuleFor(s => s.City, f => f.Random.Word())
                .RuleFor(s => s.Movie_ID, f => f.IndexFaker);    //MovieID
            return HallGenerator.Generate(count);
            }//CinemaHall

            public List<Showtime> GenerateShowtime(int count, List<CinemaHall> halls)
            {
            var ShowTimeGenerator = new Faker<Showtime>()   //Showtime

                .RuleFor(st => st.Showtime_ID, f => f.IndexFaker)
                .RuleFor(st => st.Hall_ID, f => f.IndexFaker)   //HallID
                //.RuleFor(st => st.Movie, f => f.IndexFaker) //????, nie łapie ani INT ani STRING
                .RuleFor(st => st.Day, f => f.Person.DateOfBirth)
                .RuleFor(st => st.Time, f => f.Person.DateOfBirth);
            return ShowTimeGenerator.Generate(count);
            }//Showtime

            public List<Movie> GenerateMovie(int count)
            {
            var MovieGenerator = new Faker<Movie>()     //Movie

                .RuleFor(m => m.Film_ID, f => f.IndexFaker)
                .RuleFor(m => m.Title, f => f.Random.Word())
                .RuleFor(m => m.Description, f => f.Random.Word())
              //.RuleFor(m => m.Categories, f => f.IndexFaker) ??, nie łapie ani INT ani STRING
                .RuleFor(m => m.Duration, f => f.Random.Int(90, 200));
            return MovieGenerator.Generate(count);
            }//Movie

            public List<ActorsInMovies> GenerateActorsInMovie(int count, List<Actors> actors, List<Movie> movies)
            {
            var ActorsInMovieGenerator = new Faker<ActorsInMovies>()    //ActorsinMovie

                .RuleFor(am => am.ActorsFilms_ID, f => f.IndexFaker)
                .RuleFor(am => am.Actor_ID, f => f.IndexFaker)
                .RuleFor(am => am.Movie_ID, f => f.IndexFaker);
            return ActorsInMovieGenerator.Generate(count);
            }//ActorsInMovie

            public List<Actors> GenerateActors(int count)
            {
            var ActorsGenerator = new Faker<Actors>()       //Actors

                .RuleFor(a => a.Actor_ID, f => f.IndexFaker)
                .RuleFor(a => a.FullName, f => f.Person.FullName);
            return ActorsGenerator.Generate(count);
            }//Actors

            public List<CategoriesAndMovies> GenerateCategoriesAndMovies(int count, List<Categories> categories, List<Movie>movie)
            {
            var CategoryMovieGenerator = new Faker<CategoriesAndMovies>()       //CategoryMovie

                .RuleFor(cm => cm.Movie_ID, f => f.IndexFaker)
                .RuleFor(cm => cm.CategoriesAndFilms_ID, f => f.IndexFaker)
                .RuleFor(cm => cm.Category_ID, f => f.IndexFaker);
            return CategoryMovieGenerator.Generate(count);
            }//Categories and Movies

            public List<Categories> GenerateCategories(int  count)
            {
            var CategoryGenerator = new Faker<Categories>()     //Category

                .RuleFor(c => c.Categorie_ID, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Random.Word())
                .RuleFor(c => c.Description, f => f.Random.Word());
            return CategoryGenerator.Generate(count);
            }//Categories

            public List<Directors> GenerateDirectors(int count)
            {
            var DirectorGenerator = new Faker<Directors>()      //Director

                .RuleFor(d => d.Director_ID, f => f.IndexFaker)
                //.RuleFor(d => d.Movies, f => f.IndexFaker) ????, nie łapie ani INT ani STRING
                .RuleFor(d => d.FullName, f => f.Person.FullName);
            return DirectorGenerator.Generate(count);
            }//Directors

            


        public void Seed(AppDBContext context )
        {
            Randomizer.Seed = new Random(123);
            var generator = new DataGenerator();

                      
            var customers = generator.GenerateCustomer(100);    // <-- czy dodawac reservationID?
            var account = generator.GenerateAccount(100);                                              
            var movie = generator.GenerateMovie(100);
            var hall = generator.GenerateHall(100,movie);  
            var seat = generator.GenerateSeats(100,hall);
            var showtime = generator.GenerateShowtime(100,hall);            
            var actors = generator.GenerateActors(100);       
            var actorsmovie = generator.GenerateActorsInMovie(100,actors,movie);
            var category = generator.GenerateCategories(100);     
            var categorymovie = generator.GenerateCategoriesAndMovies(100,category,movie);
            var director = generator.GenerateDirectors(100);
            var reservations = generator.GenerateReservation(100,customers,account,seat,hall);


            using (var dbContext = new AppDBContext())          //idk czemu nasz context podkreśla
            {
                dbContext.Accounts.AddRange(account);
                dbContext.Reservations.AddRange(reservations);
                dbContext.Customers.AddRange(customers);
                dbContext.Seats.AddRange(seat);
                dbContext.CinemaHalls.AddRange(hall);
                dbContext.Actors.AddRange(actors);  
                dbContext.Showtimes.AddRange(showtime);
                dbContext.Movies.AddRange(movie);
                dbContext.actorsInMovies.AddRange(actorsmovie);
                dbContext.Categories.AddRange(category);
                dbContext.Directors.AddRange(director);
                dbContext.CategoriesAndMovies.AddRange(categorymovie);
            }

        }

    }
    
}
