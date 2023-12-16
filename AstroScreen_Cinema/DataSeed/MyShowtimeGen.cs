using System;
using AstroScreen_Cinema.Models;
using AstroScreen_Cinema.Views.NowShowing;
using Microsoft.EntityFrameworkCore;

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
                            Movie = _appContext.Movies
                                    .Include(m => m.Director) // Ensure Director is loaded
                                    .FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("1d37a159-907a-4342-e345-08dbf5004f72"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("f47e3102-ceb0-4b9e-abcb-08dbfd4f37cb"))),
                            Day = showTime.AddDays((int)dayOfWeek + week*7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        _appContext.Add(schedule);
                        _appContext.SaveChanges();
                        //myShowtimes.Add(schedule);
                    }           
                }
            }
            #endregion

            #region
            for (int week = 0; week < 3; week++)
            {
                foreach (var dayOfWeek in daysOfWeek)
                {
                    foreach (var showTime in showTimesFORAvatar)
                    {
                        var schedule = new Showtime()
                        {
                            Movie = _appContext.Movies
                                    .Include(m => m.Director) // Ensure Director is loaded
                                    .FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("1d37a159-907a-4342-e345-08dbf5004f72"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("1b22f2aa-69a4-40e7-abce-08dbfd4f37cb"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        _appContext.Add(schedule);
                        _appContext.SaveChanges();
                        //myShowtimes.Add(schedule);
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("c9cfdae4-ed3c-4515-4129-08dbf4ffc769"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("f47e3102-ceb0-4b9e-abcb-08dbfd4f37cb"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        _appContext.Add(schedule);
                        _appContext.SaveChanges();
                        //myShowtimes.Add(schedule);
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("f4590b8c-9abc-42f7-e346-08dbf5004f72"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("f47e3102-ceb0-4b9e-abcb-08dbfd4f37cb"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        _appContext.Add(schedule);
                        _appContext.SaveChanges();
                        //myShowtimes.Add(schedule);
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("db04cebf-074b-4ff9-e347-08dbf5004f72"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("7b11c45a-4dab-4138-abcc-08dbfd4f37cb"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        _appContext.Add(schedule);
                        _appContext.SaveChanges();
                        //myShowtimes.Add(schedule);
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("dc6b4218-61e7-4192-e348-08dbf5004f72"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("7b11c45a-4dab-4138-abcc-08dbfd4f37cb"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        _appContext.Add(schedule);
                        _appContext.SaveChanges();
                        //myShowtimes.Add(schedule);
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("f3206f54-f7bf-414b-e349-08dbf5004f72"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("7b11c45a-4dab-4138-abcc-08dbfd4f37cb"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        _appContext.Add(schedule);
                        _appContext.SaveChanges();
                        myShowtimes.Add(schedule);
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("f9435820-e78c-4e21-e34a-08dbf5004f72"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("d782d353-5c6d-4eaf-abcd-08dbfd4f37cb"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        _appContext.Add(schedule);
                        _appContext.SaveChanges();
                        myShowtimes.Add(schedule);
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("b357d1f1-ff16-48a7-e34b-08dbf5004f72"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("d782d353-5c6d-4eaf-abcd-08dbfd4f37cb"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        _appContext.Add(schedule);
                        _appContext.SaveChanges();
                        myShowtimes.Add(schedule);
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("5a77513f-fc82-4076-e34c-08dbf5004f72"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("ddf1c6d4-a7a4-4f75-5db1-08dbde0a2fea"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        //_appContext.Add(schedule);
                        //_appContext.SaveChanges();
                        myShowtimes.Add(schedule);
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("f22f847d-2ab2-4159-e34d-08dbf5004f72"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("1b22f2aa-69a4-40e7-abce-08dbfd4f37cb"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        _appContext.Add(schedule);
                        _appContext.SaveChanges();
                        myShowtimes.Add(schedule);
                    }
                }
            }
            #endregion
            
            return myShowtimes;
        }
	}
}

