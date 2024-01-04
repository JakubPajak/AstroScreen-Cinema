using System;
using AstroScreen_Cinema.Models;
using AstroScreen_Cinema.Models.EntitiesDto;

namespace AstroScreen_Cinema.Services
{
    public class HallReperuairService : IHallReperuairService
    {
        private readonly AppDBContext _appDBContext;

        public HallReperuairService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public HallDto GetHall(string _city, string _showtimeId)
        {
            var hall = _appDBContext.CinemaHalls.FirstOrDefault(c => c.City.Equals(_city));

            var selectedSeats = this.DisplayReservedSeats(_showtimeId);

            return new HallDto()
            {
                City = hall.City,
                NumberOfRows = hall.RowNum,
                NumberOfSeats = hall.NumOfSeats,
                SelectedSeats = selectedSeats,
            };
        }

        private List<SeatDto> DisplayReservedSeats(string _showtimeId)
        {
            var SelectedSeats = new List<SeatDto>();
            var hallId = _appDBContext.Showtimes.FirstOrDefault(s => s.Showtime_ID.Equals(Guid.Parse(_showtimeId)));

            var seats = _appDBContext.Seats.Where(s => s.Hall_ID.Equals(hallId.Hall_ID) && s.Reservation.Showtime_ID.Equals(Guid.Parse(_showtimeId)));

            if (seats.Any())
            {
                foreach (var seat in seats)
                {
                    var seatTemp = new SeatDto
                    {
                        RowNumber = seat.RowNum,
                        SeatNumber = seat.SeatNum,
                    };
                    SelectedSeats.Add(seatTemp);
                }
            }

            return SelectedSeats;
        }
    }
}
