using AstroScreen_Cinema.Models.EntitiesDto;

namespace AstroScreen_Cinema.Services
{
    public interface IHomeService
    {
        Task<List<MovieDto>> GetMovies();
    }
}