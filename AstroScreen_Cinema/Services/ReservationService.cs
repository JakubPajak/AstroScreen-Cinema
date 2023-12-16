using System;
using AstroScreen_Cinema.Models;

namespace AstroScreen_Cinema.Services
{
	public class ReservationService
	{
        private readonly AppDBContext _appDBContext;

        public ReservationService(AppDBContext appDBContext)
		{
			_appDBContext = appDBContext;
		}

	}
}



 