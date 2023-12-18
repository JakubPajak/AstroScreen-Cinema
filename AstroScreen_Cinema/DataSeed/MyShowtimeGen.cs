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
                                    .FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("E1C2B466-9BE0-48CA-3DB5-08DBFF332D83"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("AF768323-970D-40C9-744C-08DBFF33728B"))),
                            Day = showTime.AddDays((int)dayOfWeek + week*7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        //_appContext.Add(schedule);
                        //_appContext.SaveChanges();
                        //myShowtimes.Add(schedule);
                    }           
                }
            }
            #endregion

            #region Avatar another hall
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
                                    .FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("E1C2B466-9BE0-48CA-3DB5-08DBFF332D83"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("63C06AD9-66BE-4C3D-744D-08DBFF33728B"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        //_appContext.Add(schedule);
                        //_appContext.SaveChanges();
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("243DCC72-7E8D-4587-3DB6-08DBFF332D83"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("93F8CA38-6E0A-47A9-744E-08DBFF33728B"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        //_appContext.Add(schedule);
                        //_appContext.SaveChanges();
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("142D4E2A-6954-479F-3DB7-08DBFF332D83"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("F043C8E9-3219-4447-744F-08DBFF33728B"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        //_appContext.Add(schedule);
                        //_appContext.SaveChanges();
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("5E8716C2-E67F-47FE-3DB8-08DBFF332D83"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("AF768323-970D-40C9-744C-08DBFF33728B"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        //_appContext.Add(schedule);
                        //_appContext.SaveChanges();
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("F41F3F3B-E92B-400C-3DB9-08DBFF332D83"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("63C06AD9-66BE-4C3D-744D-08DBFF33728B"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        //_appContext.Add(schedule);
                        //_appContext.SaveChanges();
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("F243016B-D372-4F0E-3DBA-08DBFF332D83"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("93F8CA38-6E0A-47A9-744E-08DBFF33728B"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        //_appContext.Add(schedule);
                        //_appContext.SaveChanges();
                        //myShowtimes.Add(schedule);
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("796F3B9D-AD90-464E-3DBB-08DBFF332D83"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("F043C8E9-3219-4447-744F-08DBFF33728B"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        //_appContext.Add(schedule);
                        //_appContext.SaveChanges();
                        //myShowtimes.Add(schedule);
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("455953C0-7C19-416F-3DBC-08DBFF332D83"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("AF768323-970D-40C9-744C-08DBFF33728B"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        //_appContext.Add(schedule);
                        //_appContext.SaveChanges();
                        //myShowtimes.Add(schedule);
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("06D853F2-84C6-4948-3DBD-08DBFF332D83"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("63C06AD9-66BE-4C3D-744D-08DBFF33728B"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        //_appContext.Add(schedule);
                        //_appContext.SaveChanges();
                        //myShowtimes.Add(schedule);
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
                            Movie = _appContext.Movies.FirstOrDefault(m => m.Film_ID.Equals(Guid.Parse("529D0E16-7CBF-4620-3DBE-08DBFF332D83"))),
                            CinemaHall = _appContext.CinemaHalls.FirstOrDefault(m => m.Hall_ID.Equals(Guid.Parse("93F8CA38-6E0A-47A9-744E-08DBFF33728B"))),
                            Day = showTime.AddDays((int)dayOfWeek + week * 7).Date,
                            Time = showTime.AddDays((int)dayOfWeek + week * 7).Date + showTime.TimeOfDay
                        };
                        //myShowtimes.Add(schedule);
                        //_appContext.Add(schedule);
                        //_appContext.SaveChanges();
                        //myShowtimes.Add(schedule);
                    }
                }
            }
            #endregion
            
            return myShowtimes;
        }
	}
}

