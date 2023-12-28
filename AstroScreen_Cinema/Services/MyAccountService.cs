using System;
using AstroScreen_Cinema.Models;
using AstroScreen_Cinema.Models.EntitiesDto;
using static AstroScreen_Cinema.Services.EmailService;

namespace AstroScreen_Cinema.Services
{
    public class MyAccountService : IMyAccountService
    {
        private readonly AppDBContext _appDBContext;
        private readonly IEmailService _emailService;
        private readonly ILogger<MyAccountService> _logger;

        public MyAccountService(ILogger<MyAccountService> logger, AppDBContext appDBContext, IEmailService emailService)
        {
            _appDBContext = appDBContext;
            _emailService = emailService;
            _logger = logger;
        }

        public MyAccountDto GetAccountData(string _login)
        {
            var myAccount = new MyAccountDto();
            var user = _appDBContext.Accounts.FirstOrDefault(a => a.Email.Equals(_login));

            var reservations = _appDBContext.Reservations
                .Where(r => r.Account_ID.Equals(user.Account_ID));


            myAccount.Name = user.Name;
            myAccount.Surname = user.Surname;
            myAccount.PhoneNum = user.PhoneNum;
            myAccount.Email = user.Email;
            myAccount.Birthdate = user.Birthdate;

            foreach (var reservation in reservations)
            {
                var reservationDto = _appDBContext.Showtimes
                        .Where(sh => sh.Showtime_ID.Equals(reservation.Showtime_ID))
                        .Join(
                            _appDBContext.Movies,
                            showtime => showtime.Movie_ID,
                            movie => movie.Film_ID,
                            (showtime, movie) => new ReservationDto
                            {
                                Showtime = showtime,
                                //Movie = movie,
                            })
                        .FirstOrDefault();

                myAccount.ReservationDetails.Add(reservation.Reservation_ID.ToString(), reservationDto);
            }
            

            return myAccount;
        }

        public async Task<bool> ChangeDataService(MyAccountDto myAccountDto)
        {
            var account = _appDBContext.Accounts.FirstOrDefault(a => a.Email.Equals(myAccountDto.Email));

            account.Name = myAccountDto.Name;
            account.Surname = myAccountDto.Surname;
            account.PhoneNum = myAccountDto.PhoneNum;
            account.Email = myAccountDto.Email;
            account.Birthdate = myAccountDto.Birthdate;

            _appDBContext.Update(account);
            try
            {
                await _appDBContext.SaveChangesAsync();

                await _emailService.SendMail(EmailAction.PASSWORD_CHANGE, account.Email);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Email", "Log to email file");    
            }

            return true;
        }

        public List<ViewHistory> GetViewingHistory(string login)
        {
            var dispToUserList = new List<ViewHistory>();
            var account = _appDBContext.Accounts.FirstOrDefault(a => a.Email.Equals(login));

            var reservations = _appDBContext.Reservations.Where(r => r.Account_ID.Equals(account.Account_ID));

            foreach (var reservation in reservations)
            {
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

