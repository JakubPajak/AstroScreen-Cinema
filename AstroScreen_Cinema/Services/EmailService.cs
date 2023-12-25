using System;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog.Context;

namespace AstroScreen_Cinema.Services
{
	public class EmailService
	{
        private readonly ILogger _logger;

        public enum EmailAction
        {
            REGISTER,
            CONFIRMATION,
            PASSWORD_CHANGE,
            NEWSLETTER,
            REMINDER,
        };

		public EmailService(ILogger logger)
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
                    case EmailAction.REGISTER:
                        message = MailHelper.CreateSingleTemplateEmail(from, to, "d-463443cbc9774187aa9a5731fa165579", new
                        {
                            movietitle = "Avatar",
                            seats = "A1"
                        });
                        break;
                    case EmailAction.CONFIRMATION:

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
            catch(Exception ex)
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

