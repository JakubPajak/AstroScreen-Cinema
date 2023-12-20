using AstroScreen_Cinema.Models.EntitiesDto;

namespace AstroScreen_Cinema.Services
{
    public interface INowShowingService
    {
        List<RepertoireDto> GetRepertoires(DateTime date, string _city);
        List<RepertoireDto> GetUniqueMoviesWithHours(List<RepertoireDto> repertoires, string _city);
    }
}