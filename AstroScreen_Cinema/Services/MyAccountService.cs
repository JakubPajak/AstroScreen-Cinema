using System;
using AstroScreen_Cinema.Models;
using AstroScreen_Cinema.Models.EntitiesDto;

namespace AstroScreen_Cinema.Services
{
	public class MyAccountService
	{
        private readonly AppDBContext _appDBContext;

        public MyAccountService(AppDBContext appDBContext)
		{
			_appDBContext = appDBContext;
		}

		public MyAccountDto GetAccountData(string _login)
		{
			var user = _appDBContext.Accounts.FirstOrDefault(a => a.Email.Equals(_login));

			var userAccount = new MyAccountDto()
			{
				Name = user.Name,
				SecondName = user.Surname,
				PhoneNum = user.PhoneNum,
				EmailAddress = user.Email,
				BirthDate = user.Birthdate
			};

			return userAccount;
		}

		public async Task<bool> ChangeDataService(MyAccountDto myAccountDto)
		{
			var account = _appDBContext.Accounts.FirstOrDefault(a => a.Email.Equals(myAccountDto.EmailAddress));

			account.Name = myAccountDto.Name;
			account.Surname = myAccountDto.SecondName;
			account.PhoneNum = myAccountDto.PhoneNum;
			account.Email = myAccountDto.EmailAddress;
			account.Birthdate = myAccountDto.BirthDate;

			_appDBContext.Update(account);
			int affectedRows = await _appDBContext.SaveChangesAsync();

			return affectedRows == 1 ? true : throw new BadHttpRequestException("Could not correcly save the data into the database");
		}

		public List<ViewHistory> GetViewingHistory(string login)
		{
			var dispToUserList = new List<ViewHistory>();
			var account = _appDBContext.Accounts.FirstOrDefault(a => a.Email.Equals(login));

			var reservations = _appDBContext.Reservations.Where(r => r.Account_ID.Equals(account.Account_ID));

			foreach (var reservation in reservations) {
				var showtime = _appDBContext.Showtimes.FirstOrDefault(sh => sh.Showtime_ID.Equals(reservation.Showtime_ID));

				var movie = _appDBContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(showtime.Movie_ID));

				var dispToUser = new ViewHistory
				{
					Title = movie.Title,
					Description = movie.Description,
					Duration = movie.Duration,
					ShowtimeId = showtime.Showtime_ID,
					ReservationId = reservation.Reservation_ID
				};
				dispToUserList.Add(dispToUser);
            }

			return dispToUserList;
		}

    }
}

