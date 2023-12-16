using AstroScreen_Cinema.Models.EntitiesDto;

namespace AstroScreen_Cinema.Services
{
    public interface IMyAccountService
    {
        Task<bool> ChangeDataService(MyAccountDto myAccountDto);
        MyAccountDto GetAccountData(string _login);
        List<ViewHistory> GetViewingHistory(string login);
    }
}