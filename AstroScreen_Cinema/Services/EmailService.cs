using System;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog.Context;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroScreen_Cinema.Models.EntitiesDto;

namespace AstroScreen_Cinema.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public enum EmailAction
        {
            REGISTER,
            CONFIRMATION,
            PASSWORD_CHANGE,
            NEWSLETTER,
            REMINDER,
        };

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public async Task<bool> SendMail<T>(EmailAction emailAction, string _userMail, T payload)
        {
            //Reservation details needed to send proper email
            string[] reservationDetails = null;

            //Register confirmation to send email with details
            string[] registrationDetails = null;

            //MyAccount data needed to confirm changes
            string[] changeData = null;

            var message = new SendGridMessage();
            var apiKey = "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";
            var client = new SendGridClient(apiKey);

            var to = new EmailAddress(_userMail, "Odbiorca");

            var from = new EmailAddress("astroscreencinema@gmail.com", "AstroScreen Cinema");


            switch (emailAction.GetType())
            {
                case Type t when t == typeof(ReservationDto):

                    ReservationDto reservationDto = (ReservationDto)(object)payload;

                    reservationDetails[0] = reservationDto.Showtime.Day.ToString("dd-mm-yyyy");
                    reservationDetails[1] = reservationDto.Showtime.Time.ToString("HH:mm");
                    reservationDetails[2] = reservationDto.Movie.Title;
                    reservationDetails[3] = reservationDto.Account.Name;
                    foreach (var seat in reservationDto.Seats)
                    {
                        reservationDetails[4] += seat + ", ";
                    }

                    break;

                case Type t when t == typeof(RegisterDto):

                    RegisterDto registerDto = (RegisterDto)(object)payload;

                    registrationDetails[0] = registerDto.Name + registerDto.Surname;
                    registrationDetails[1] = registerDto.Email;

                    break;

                case Type t when t == typeof(MyAccountDto):

                    MyAccountDto myAccountDto = (MyAccountDto)(object)payload;

                    changeData[0] = myAccountDto.Email;
                    changeData[1] = myAccountDto.Name + myAccountDto.Surname;
                    changeData[2] = myAccountDto.PhoneNum.ToString();

                    break;
            }

            try
            {
                switch (emailAction)
                {
                    case EmailAction.CONFIRMATION:
                        message = MailHelper.CreateSingleTemplateEmail(from, to, "d-463443cbc9774187aa9a5731fa165579", new
                        {
                            movietitle = reservationDetails[2],
                            seats = reservationDetails[4],
                            day = reservationDetails[0],
                            time = reservationDetails[1],
                            name = reservationDetails[3]
                        });
                        break;
                    case EmailAction.REGISTER:
                        message = MailHelper.CreateSingleTemplateEmail(from, to, "TEMPLATE-Register", new
                        {
                            name = registrationDetails[0],
                        });
                        break;
                    case EmailAction.PASSWORD_CHANGE:
                        message = MailHelper.CreateSingleTemplateEmail(from, to, "TEMPLATE-ChangeData", new
                        {
                            email = changeData[0],
                            name = changeData[1],
                        });
                        break;
                    case EmailAction.REMINDER:
                        message = MailHelper.CreateSingleTemplateEmail(from, to, "TEMPLATE-Reminder", new
                        {
                            movietitle = reservationDetails[2],
                            seats = reservationDetails[4],
                            day = reservationDetails[0],
                            time = reservationDetails[1],
                            name = reservationDetails[3]
                        });
                        break;
                }

                var response = await client.SendEmailAsync(message);

                var responseBody = await response.Body.ReadAsStringAsync();

                using (LogContext.PushProperty("LogType", "email"))
                {
                    _logger.LogInformation($"Error sending email! \n Action: " +
                        $"{emailAction}, UserMail: {_userMail}, Response Status: {responseBody}\n");
                }

                return true;
            }
            catch (Exception ex)
            {
                using (LogContext.PushProperty("LogType", "email"))
                {
                    _logger.LogInformation($"Error sending email! \n Action: " +
                        $"{emailAction}, UserMail: {_userMail}, Exception: {ex}\n");
                }

                throw;
            }
        }
    }
}

