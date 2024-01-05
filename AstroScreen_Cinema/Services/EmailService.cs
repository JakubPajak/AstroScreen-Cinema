using System;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog.Context;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<bool> SendMail(EmailAction emailAction, string _userMail)
        {
            var message = new SendGridMessage();
            var apiKey = "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";
            var client = new SendGridClient(apiKey);

            var to = new EmailAddress(_userMail, "Odbiorca");

            var from = new EmailAddress("astroscreencinema@gmail.com", "AstroScreen Cinema");

            try
            {
                switch (emailAction)
                {
                    case EmailAction.CONFIRMATION:
                        message = MailHelper.CreateSingleTemplateEmail(from, to, "d-463443cbc9774187aa9a5731fa165579", new
                        {
                            movietitle = "Avatar WYSŁANO MAIL AUUU NA MAILA Z BAZY AUUU",
                            seats = "A1"
                        });
                        break;
                    case EmailAction.REGISTER:

                        break;
                    case EmailAction.PASSWORD_CHANGE:

                        break;
                    case EmailAction.REMINDER:

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

