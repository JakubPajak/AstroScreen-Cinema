using static AstroScreen_Cinema.Services.EmailService;

namespace AstroScreen_Cinema.Services
{
    public interface IEmailService
    {
        public Task<bool> SendMail<T>(EmailAction emailAction, string _userMail, T payload);
    }
}