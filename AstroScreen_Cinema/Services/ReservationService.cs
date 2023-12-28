using System;
using System.Text;
using AstroScreen_Cinema.Models;
using AstroScreen_Cinema.Models.EntitiesDto;
using static AstroScreen_Cinema.Services.EmailService;

namespace AstroScreen_Cinema.Services
{
    public class ReservationService : IReservationService
    {
        private readonly AppDBContext _appDBContext;
        private readonly ILogger<ReservationService> _logger;
        private readonly IEmailService _emailService;

        public ReservationService(ILogger<ReservationService> logger, AppDBContext appDBContext, IEmailService emailService)
        {
            _appDBContext = appDBContext;
            _logger = logger;
            _emailService = emailService;
        }


        public void CacheSeatInformation(string[] _seats, out string stringOfSeats)
        {
            StringBuilder formattedString = new StringBuilder();

            foreach (var seat in _seats)
            {
                formattedString.Append(seat);
                formattedString.Append(",");
            }

            if (_seats.Length > 0)
            {
                formattedString.Length--;
            }

            stringOfSeats = formattedString.ToString();
        }


        public ReservationDto GetReservationData(string[] seats, string showtimeId,
            string _city, string _userLogin)
        {
            var reservation = new ReservationDto();
            var Seats = new List<Seats>();


            var user = _appDBContext.Accounts.FirstOrDefault(a => a.Email.Equals(_userLogin));

            var hall = _appDBContext.CinemaHalls.FirstOrDefault(c =>
                        c.City.Equals(_city));

            var showtime = _appDBContext.Showtimes.FirstOrDefault(s =>
                            s.Showtime_ID.Equals(Guid.Parse(showtimeId)));
            var movie = _appDBContext.Movies.FirstOrDefault(m =>
                            m.Film_ID.Equals(showtime.Movie_ID));

            if (user == null)
            {
                user = new Account()
                {
                    Name = "Default",
                    Surname = "Default",
                    Email = "Default",
                    Password = "Default",
                    IsRegistered = false,
                    Birthdate = DateTime.MinValue,
                    PhoneNum = 0,
                };
            }

            foreach (var seat in seats)
            {
                string letterPart = seat.ToString().Substring(0, 1);
                string numberPart = new String(seat.SkipWhile(c => !Char.IsDigit(c)).ToArray());
                var seatTemp = new Seats()
                {
                    //Adding the seats that were selected 
                    RowNum = char.ToUpper(letterPart[0]) - 'A' + 1,
                    SeatNum = int.Parse(numberPart),
                    IsReserved = true,
                    CinemaHall = hall,
                };
                Seats.Add(seatTemp);
            }

            reservation.Seats = Seats;
            reservation.Reservation_date = DateTime.Now;
            reservation.Showtime = showtime;
            reservation.Showtime.Movie = movie;
            reservation.Account = user;
            return reservation;
        }

        public async Task<bool> SaveTheReservation(ReservationDto _reservationDto, string _showtimeId,
            string _user, string[] _seats, string _city)
        {
            var newUser = new Account();
            var newReservation = new Reservation();
            var newSeat = new List<Seats>();


            //Adding new user to the database if the user is not yet to be found in
            //the data
            #region
            if (_user == null)
            {
                newUser.Name = _reservationDto.Account.Name;
                newUser.Surname = _reservationDto.Account.Surname;
                newUser.Email = _reservationDto.Account.Email;
                if (_reservationDto.IsRegistered)
                {
                    newUser.IsRegistered = true;
                    newUser.Password = _reservationDto.Account.Password;
                }
                else
                {
                    newUser.IsRegistered = false;
                    newUser.Password = "";
                }
                newUser.Birthdate = _reservationDto.Account.Birthdate;
                newUser.PhoneNum = _reservationDto.Account.PhoneNum;

                await _appDBContext.AddAsync(newUser);
            }
            #endregion


            //Creating new Seat record
            #region
            foreach (var seat in _seats)
            {
                string letterPart = seat.ToString().Substring(0, 1);
                string numberPart = new String(seat.SkipWhile(c => !Char.IsDigit(c)).ToArray());
                var seatTemp = new Seats()
                {
                    //Adding the seats that were selected 
                    RowNum = char.ToUpper(letterPart[0]) - 'A' + 1,
                    SeatNum = int.Parse(numberPart),
                    IsReserved = true,
                    CinemaHall = _appDBContext.CinemaHalls.FirstOrDefault(c => c.City.Equals(_city)),
                };
                newSeat.Add(seatTemp);
            }

            await _appDBContext.AddRangeAsync(newSeat);
            #endregion


            //Creating new Reservation record
            #region
            newReservation.Reservation_date = DateTime.Now;
            newReservation.Email = _reservationDto.Account.Email;
            newReservation.PhoneNum = _reservationDto.Account.PhoneNum;
            newReservation.Name = _reservationDto.Account.Name;
            newReservation.Surname = _reservationDto.Account.Surname;
            newReservation.Birthdate = _reservationDto.Account.Birthdate;
            newReservation.IsRegistered = _reservationDto.Account.IsRegistered;
            newReservation.Showtime = _appDBContext.Showtimes.FirstOrDefault(sh =>
                                        sh.Showtime_ID.Equals(Guid.Parse(_showtimeId)));
            newReservation.Account = _user == null ? newUser : _appDBContext.Accounts
                                        .FirstOrDefault(a => a.Email.Equals(_user));
            #endregion
            //In order to add seats in a correct and logical manner we have to change
            //relation between reservation and seat entity.
            //One reservation can get many seats, i do not know why this was not
            //taken into consideration at the beginning of the development process.

            await _appDBContext.AddAsync(newReservation);

            try
            {
                await _appDBContext.SaveChangesAsync();

                if (_user == null)
                    await _emailService.SendMail(EmailAction.CONFIRMATION, newUser.Email);
                else
                    await _emailService.SendMail(EmailAction.CONFIRMATION, _user);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Reservation", "Log into the reservation log file");
                return false;
            }
        }

    }

}



 