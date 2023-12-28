using AstroScreen_Cinema.Models.EntitiesDto;

namespace AstroScreen_Cinema.Services
{
    public interface IReservationService
    {
        void CacheSeatInformation(string[] _seats, out string stringOfSeats);

        ReservationDto GetReservationData(string[] seats, string showtimeId,
            string _city, string _userLogin);

        Task<bool> SaveTheReservation(ReservationDto _reservationDto, string _showtimeId,
            string _user, string[] _seats, string city);
    }
}