using System;
using System.Text;
using AstroScreen_Cinema.Models;
using AstroScreen_Cinema.Models.EntitiesDto;

namespace AstroScreen_Cinema.Services
{
	public class ReservationService
	{
        private readonly AppDBContext _appDBContext;

        public ReservationService(AppDBContext appDBContext)
		{
			_appDBContext = appDBContext;
		}


		public void CacheSeatInformation(string[] _seats, out string stringOfSeats)
		{
			StringBuilder formattedString = new StringBuilder();

			foreach (var seat in _seats)
			{
				formattedString.Append(seat);
			}

			stringOfSeats = formattedString.ToString();
		}

		public ReservationDto GetReservationData(string[] seats, string showtimeId, string _city, string _userLogin)
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

	}

}



 