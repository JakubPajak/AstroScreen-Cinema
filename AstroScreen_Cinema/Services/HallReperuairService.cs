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

        public HallDto GetHall(string _city)
        {
            var hall = _appDBContext.CinemaHalls.FirstOrDefault(c => c.City.Equals(_city));

            return new HallDto()
            {
                City = hall.City,
                NumberOfRows = hall.RowNum,
                NumberOfSeats = hall.NumOfSeats
            };
        }
    }
}

