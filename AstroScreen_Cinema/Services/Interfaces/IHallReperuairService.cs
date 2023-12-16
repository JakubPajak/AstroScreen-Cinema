using AstroScreen_Cinema.Models.EntitiesDto;

namespace AstroScreen_Cinema.Services
{
    public interface IHallReperuairService
    {
        HallDto GetHall(string city);
    }
}