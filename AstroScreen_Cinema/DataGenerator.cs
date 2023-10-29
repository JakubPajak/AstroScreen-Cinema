using AstroScreen_Cinema.Models;
using Bogus;


namespace AstroScreen_Cinema
{
    public class DataGenerator
    {
        public void Seed(AppDBContext context )
        {
            Randomizer.Seed = new Random(123);

            var ReservationGenerator = new Faker<Reservation>()     //Reservations

                .RuleFor(r => r.Reservation_ID, f => f.IndexFaker)
                .RuleFor(r => r.Reservation_date, f => f.Person.DateOfBirth)    // <-- Inny format daty nie chcial dzialac
              //.RuleFor(r => r.Customer_ID, f => CustomerGenerator.Generate())   <-- Nie chce się połączyć z Customer_ID
              //.RuleFor(r => r.Account_ID, f => AccountGenerator.Generate())   <-- Nie chce się połączyć z Account_ID
              //.RuleFor(r => r.Seat_ID, f => f.SeatsGenerator.Generate())  <-- Nie chce się połączyc z Seat_ID 
                .RuleFor(r => r.Showtime_ID, f => f.IndexFaker);

            //Reservation Reservation_ID = ReservationGenerator.Generate(); 
            var reservations = ReservationGenerator.Generate(100);

            var CustomerGenerator = new Faker<Customer>()   //Customer

                .RuleFor(c => c.Customer_ID, f => f.IndexFaker)
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Name, c.Surname))
                .RuleFor(c => c.Birthdate, f => f.Person.DateOfBirth)
                .RuleFor(c => c.Surname, f => f.Person.LastName)
                .RuleFor(c => c.Name, f => f.Person.FirstName)
                .RuleFor(c => c.PhoneNum, f => f.Random.Long(111111111, 999999999));
                //.RuleFor(c => c.Reservation_ID, f => f.PickRandom(ReservationGenerator.Generate()));  <-- IDK nie chce sie połączyć Reservation_ID
            var customers = CustomerGenerator.Generate(100);    //Creating 100 Customers

            var AccountGenerator = new Faker<Account>()     //Account

                .RuleFor(a => a.Account_ID, f => f.IndexFaker)
                .RuleFor(a => a.Name, f => f.Person.FirstName)
                .RuleFor(a => a.Email, f => f.Person.Email)
                .RuleFor(a => a.Password, f => f.Random.Word())
                .RuleFor(a => a.Birthdate, f => f.Person.DateOfBirth)
                .RuleFor(a => a.PhoneNum, f => f.Random.Long(111111111, 999999999));


            var SeatsGenerator = new Faker<Seats>()     //Seats

                .RuleFor(s => s.Seat_ID, f => f.IndexFaker)
                .RuleFor(s => s.RowNum, f => f.Random.Int(10, 20))
                .RuleFor(s => s.SeatNum, f => f.Random.Int(100, 200))
                .RuleFor(s => s.IsReserved, f => f.Random.Bool());
            //.RuleFor(s => s.Hall_ID, f => f.HallGenerator.Generate())   <-- nie chce się połączyć z Hall_ID
            //.RuleFor(s => s.Reservation_ID, f => f.ReservationGenerator.Generate())     <-- nie chce się połączyć z Reservation_ID

            var HallGenerator = new Faker<CinemaHall>()

                .RuleFor(s => s.Hall_ID, f => f.IndexFaker);
              //.RuleFor(s => s.NumOfSeats, f => f.SeatsGenerator.Generate())


        }
    }
}
