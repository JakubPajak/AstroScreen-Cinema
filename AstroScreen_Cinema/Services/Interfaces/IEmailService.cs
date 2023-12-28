namespace AstroScreen_Cinema.Services
{
    public interface IEmailService
    {
        Task<bool> SendMail(EmailService.EmailAction emailAction, string _userMail);
    }
}