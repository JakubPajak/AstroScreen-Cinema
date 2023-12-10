using System;
using AstroScreen_Cinema.Models;
using AstroScreen_Cinema.Views.NowShowing;

namespace AstroScreen_Cinema.DataSeed
{
	public class MyShowtimeGen
	{
        private readonly AppDBContext _appContext;

        public MyShowtimeGen(AppDBContext appContext)
		{
			_appContext = appContext;
		}

        public List<Showtime> GenerateShowtime()
        {
            var myShowtimes = new List<Showtime>() { };
            //Do tej listy dodawaj wygenerowane showtimy
            //Reszta analigicznie jak w pliku MyMovieGen
            //Zwracasz listę z typem generycznym Showtime, do bazy tutaj nic nie dodajesz
            //ani nie zapisujesz

            var daysOfWeek = new[]
            {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            };

            //Tutaj zamiast indexów beda wpisane id sal kinowych 
            var Halls = new[] { 1, 2, 3, 4, 5, 6 };
            //Dobra jednak jest problem.
            //Albo film jest puszczany w indywidualnej sali
            //Albo recznie trzeba te sale wpisać ale kod bedzie 4 razy dłuższy

            #region Avatar Schedule
            var showTimesFORAvatar = new[]
            {
                new DateTime(2024, 2, 1, 14, 0, 0), 
                new DateTime(2024, 2, 1, 16, 0, 0), 
                new DateTime(2024, 2, 1, 18, 0, 0),
                new DateTime(2024, 2, 1, 21, 35, 0)
            };

            

            for (int week = 0; week < 3; week++)
            {
                foreach (var dayOfWeek in daysOfWeek)
                {
                     foreach (var showTime in showTimesFORAvatar)
                     {
                        var schedule = new Showtime()
                        {
                            Movie_ID = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("FD5D7EA8-88B9-4DDF-D1E7-08DBE8F3E1AC"))),
                            Hall_ID = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("B5DC1237-051F-46B8-6AD3-08DBE8F3E1DC"))),
                            Day = showTime.AddDays((int)dayOfWeek).Date,
                            Time = showTime                                    
                        };            
                     }           
                }
            }
            #endregion

            #region Barbie Schedule
            var showTimesFORBarbie = new[]
            {
                new DateTime(2024, 2, 1, 15, 0, 0), 
                new DateTime(2024, 2, 1, 17, 0, 0), 
                new DateTime(2024, 2, 1, 18, 0, 0),  
                new DateTime(2024, 2, 1, 20, 0, 0)  
            };
            for (int week = 0; week < 3; week++)
            {
                foreach (var dayOfWeek in daysOfWeek)
                {
                    foreach (var showTime in showTimesFORBarbie)
                    {
                        var schedule = new Showtime()
                        {
                            Movie_ID = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("FD5D7EA8-88B9-4DDF-D1E7-08DBE8F3E1AC"))),
                            Hall_ID = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("B5DC1237-051F-46B8-6AD3-08DBE8F3E1DC"))),
                            Day = showTime.AddDays((int)dayOfWeek).Date,
                            Time = showTime
                        };
                    }
                }
            }
            #endregion

            #region Batman Schedule
            var showTimesFORBatman = new[]
            {
                new DateTime(2024, 2, 1, 12, 0, 0),
                new DateTime(2024, 2, 1, 16, 0, 0),
                new DateTime(2024, 2, 1, 18, 30, 0),
                new DateTime(2024, 2, 1, 21, 45, 0)
            };
            for (int week = 0; week < 3; week++)
            {
                foreach (var dayOfWeek in daysOfWeek)
                {
                    foreach (var showTime in showTimesFORBatman)
                    {
                        var schedule = new Showtime()
                        {
                            Movie_ID = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("FD5D7EA8-88B9-4DDF-D1E7-08DBE8F3E1AC"))),
                            Hall_ID = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("B5DC1237-051F-46B8-6AD3-08DBE8F3E1DC"))),
                            Day = showTime.AddDays((int)dayOfWeek).Date,
                            Time = showTime
                        };
                    }
                }
            }
            #endregion

            #region Black Widow Schedule
            var showTimesFORWidow = new[]
            {
                new DateTime(2024, 2, 1, 13, 0, 0),
                new DateTime(2024, 2, 1, 15, 15, 0),
                new DateTime(2024, 2, 1, 17, 30, 0),
                new DateTime(2024, 2, 1, 20, 45, 0),
                new DateTime(2024, 2, 1, 22, 30, 0)
            };
            for (int week = 0; week < 3; week++)
            {
                foreach (var dayOfWeek in daysOfWeek)
                {
                    foreach (var showTime in showTimesFORWidow)
                    {
                        var schedule = new Showtime()
                        {
                            Movie_ID = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("FD5D7EA8-88B9-4DDF-D1E7-08DBE8F3E1AC"))),
                            Hall_ID = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("B5DC1237-051F-46B8-6AD3-08DBE8F3E1DC"))),
                            Day = showTime.AddDays((int)dayOfWeek).Date,
                            Time = showTime
                        };
                    }
                }
            }
            #endregion

            #region Cruella Schedule
            var showTimesFORCruella = new[]
            {
                new DateTime(2024, 2, 1, 15, 0, 0),
                new DateTime(2024, 2, 1, 17, 15, 0),
                new DateTime(2024, 2, 1, 19, 30, 0)
            };
            for (int week = 0; week < 3; week++)
            {
                foreach (var dayOfWeek in daysOfWeek)
                {
                    foreach (var showTime in showTimesFORCruella)
                    {
                        var schedule = new Showtime()
                        {
                            Movie_ID = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("FD5D7EA8-88B9-4DDF-D1E7-08DBE8F3E1AC"))),
                            Hall_ID = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("B5DC1237-051F-46B8-6AD3-08DBE8F3E1DC"))),
                            Day = showTime.AddDays((int)dayOfWeek).Date,
                            Time = showTime
                        };
                    }
                }
            }
            #endregion

            #region LOTR Schedule
            var showTimesFORLOTR = new[]
            {
                new DateTime(2024, 2, 1, 12, 0, 0),
                new DateTime(2024, 2, 1, 17, 0, 0),
                new DateTime(2024, 2, 1, 21, 0, 0)
            };
            for (int week = 0; week < 3; week++)
            {
                foreach (var dayOfWeek in daysOfWeek)
                {
                    foreach (var showTime in showTimesFORLOTR)
                    {
                        var schedule = new Showtime()
                        {
                            Movie_ID = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("FD5D7EA8-88B9-4DDF-D1E7-08DBE8F3E1AC"))),
                            Hall_ID = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("B5DC1237-051F-46B8-6AD3-08DBE8F3E1DC"))),
                            Day = showTime.AddDays((int)dayOfWeek).Date,
                            Time = showTime
                        };
                    }
                }
            }
            #endregion

            #region Nun Schedule
            var showTimesFORNun = new[]
            {
                new DateTime(2024, 2, 1, 20, 0, 0),
                new DateTime(2024, 2, 1, 22, 0, 0),
                new DateTime(2024, 2, 1, 23, 50, 0)
            };
            for (int week = 0; week < 3; week++)
            {
                foreach (var dayOfWeek in daysOfWeek)
                {
                    foreach (var showTime in showTimesFORNun)
                    {
                        var schedule = new Showtime()
                        {
                            Movie_ID = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("FD5D7EA8-88B9-4DDF-D1E7-08DBE8F3E1AC"))),
                            Hall_ID = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("B5DC1237-051F-46B8-6AD3-08DBE8F3E1DC"))),
                            Day = showTime.AddDays((int)dayOfWeek).Date,
                            Time = showTime
                        };
                    }
                }
            }
            #endregion

            #region Oppenheimer Schedule
            var showTimesFOROpp = new[]
            {
                new DateTime(2024, 2, 1, 15, 0, 0),
                new DateTime(2024, 2, 1, 18, 0, 0),
                new DateTime(2024, 2, 1, 20, 50, 0),
                new DateTime(2024, 2, 1, 23, 30, 0)
            };
            for (int week = 0; week < 3; week++)
            {
                foreach (var dayOfWeek in daysOfWeek)
                {
                    foreach (var showTime in showTimesFOROpp)
                    {
                        var schedule = new Showtime()
                        {
                            Movie_ID = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("FD5D7EA8-88B9-4DDF-D1E7-08DBE8F3E1AC"))),
                            Hall_ID = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("B5DC1237-051F-46B8-6AD3-08DBE8F3E1DC"))),
                            Day = showTime.AddDays((int)dayOfWeek).Date,
                            Time = showTime
                        };
                    }
                }
            }
            #endregion

            #region Spiderman Schedule
            var showTimesFORSpiderman = new[]
            {
                new DateTime(2024, 2, 1, 13, 0, 0),
                new DateTime(2024, 2, 1, 16, 15, 0),
                new DateTime(2024, 2, 1, 18, 30, 0),
                new DateTime(2024, 2, 1, 20, 50, 0)
            };
            for (int week = 0; week < 3; week++)
            {
                foreach (var dayOfWeek in daysOfWeek)
                {
                    foreach (var showTime in showTimesFORSpiderman)
                    {
                        var schedule = new Showtime()
                        {
                            Movie_ID = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("FD5D7EA8-88B9-4DDF-D1E7-08DBE8F3E1AC"))),
                            Hall_ID = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("B5DC1237-051F-46B8-6AD3-08DBE8F3E1DC"))),
                            Day = showTime.AddDays((int)dayOfWeek).Date,
                            Time = showTime
                        };
                    }
                }
            }
            #endregion

            #region Thor Schedule
            var showTimesFORThor = new[]
            {
                new DateTime(2024, 2, 1, 15, 0, 0),
                new DateTime(2024, 2, 1, 16, 15, 0),
                new DateTime(2024, 2, 1, 18, 45, 0),
                new DateTime(2024, 2, 1, 20, 50, 0)
            };
            for (int week = 0; week < 3; week++)
            {
                foreach (var dayOfWeek in daysOfWeek)
                {
                    foreach (var showTime in showTimesFORThor)
                    {
                        var schedule = new Showtime()
                        {
                            Movie_ID = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("FD5D7EA8-88B9-4DDF-D1E7-08DBE8F3E1AC"))),
                            Hall_ID = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("B5DC1237-051F-46B8-6AD3-08DBE8F3E1DC"))),
                            Day = showTime.AddDays((int)dayOfWeek).Date,
                            Time = showTime
                        };
                    }
                }
            }
            #endregion

            return myShowtimes;
        }
	}
}

