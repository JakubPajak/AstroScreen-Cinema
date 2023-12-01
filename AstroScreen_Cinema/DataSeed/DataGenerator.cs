using AstroScreen_Cinema.Models;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using AstroScreen_Cinema.DataSeed;

namespace AstroScreen_Cinema
{
    public class DataGenerator
    {
        public readonly AppDBContext _appContext;
        private readonly DataSeeding _dataSeeding;

        public DataGenerator(AppDBContext appContext, DataSeeding dataSeeding)
        {
            _appContext = appContext;
            _dataSeeding = dataSeeding;
        }

        public Task Seed()
        {
            var myMovies = new List<Movie>();
            Randomizer.Seed = new Random(123);
            //int count = 100;


            var DirectorGenerator = new Faker<Directors>()      
                .RuleFor(d => d.FullName, f => f.Person.FullName);


            var ActorsGenerator = new Faker<Actors>()       
                .RuleFor(a => a.FullName, f => f.Person.FullName);


            var MovieGenerator = new Faker<Movie>()
                .RuleFor(m => m.Title, f => f.Random.Word())
                .RuleFor(m => m.Description, f => f.Random.Word())
                .RuleFor(m => m.Duration, f => f.Random.Int(90, 200))
                .RuleFor(m => m.Director, f => DirectorGenerator.Generate());


             var HallGenerator = new Faker<CinemaHall>()
                .RuleFor(s => s.NumOfSeats, f => f.Random.Int(100, 200))
                .RuleFor(s => s.RowNum, f => f.Random.Int(10, 20))   //RowNum
                .RuleFor(s => s.SeatNum, f => f.Random.Int(100, 200))  //SeatNum
                .RuleFor(s => s.City, f => f.Address.City());


            // Poprawka wymagana
            //Movie dodane i dziala razem z direvtory
            var ShowTimeGenerator = new Faker<Showtime>()
                .RuleFor(st => st.Day, f => f.Date.Recent())
                .RuleFor(st => st.Time, f => f.Date.Recent())
                .RuleFor(s => s.CinemaHall, f => HallGenerator.Generate())
                .RuleFor(s => s.Movie, f => MovieGenerator.Generate());



             var AccountGenerator = new Faker<Account>()
                .RuleFor(a => a.Name, f => f.Person.FirstName)
                .RuleFor(a => a.Surname, f => f.Person.LastName)
                .RuleFor(a => a.Email, f => f.Person.Email)
                .RuleFor(a => a.Password, f => f.Random.Word())
                .RuleFor(a => a.Birthdate, f => f.Person.DateOfBirth)
                .RuleFor(a => a.PhoneNum, f => f.Random.Number(111111111, 999999999));



              var CategoryGenerator = new Faker<Categories>() 
                .RuleFor(c => c.Name, f => f.Random.Word())
                .RuleFor(c => c.Description, f => f.Lorem.Sentences(4));


              var SeatsGenerator = new Faker<Seats>()  
                .RuleFor(s => s.RowNum, f => f.Random.Int(10, 20))
                .RuleFor(s => s.SeatNum, f => f.Random.Int(100, 200))
                .RuleFor(s => s.IsReserved, f => f.Random.Bool())
                .RuleFor(s => s.CinemaHall, f => HallGenerator.Generate());   


              var ReservationGenerator = new Faker<Reservation>()     
                .RuleFor(r => r.Reservation_date, f => f.Person.DateOfBirth)    
                .RuleFor(r => r.Name, f => f.Person.FirstName)
                .RuleFor(r => r.Surname, f => f.Person.LastName)
                .RuleFor(r => r.Email, f => f.Person.Email)
                .RuleFor(r => r.PhoneNum, f => f.Random.Number(111111111, 999999999))
                .RuleFor(r => r.Seat, f => SeatsGenerator.Generate())
                .RuleFor(r => r.Showtime, f => ShowTimeGenerator.Generate())
                .RuleFor(r => r.Account, f => AccountGenerator.Generate());




            var ActorsInMovieGenerator = new Faker<ActorsInMovies>()    //ActorsinMovie
             .RuleFor(a => a.Actor, f => ActorsGenerator.Generate())
             .RuleFor(a => a.Movie, f => MovieGenerator.Generate());


            var CategoryMovieGenerator = new Faker<CategoriesAndMovies>()       //CategoryMovie
              .RuleFor(c => c.Categories, f => CategoryGenerator.Generate())
              .RuleFor(c => c.Movies, f => MovieGenerator.Generate());


            //----------------------------ADDING REAL MOVIES--------------------------------------------//
            
            //------Soon In Cinemas / Also now showing------
            //Avatar
            var Avatar = new Movie()
            {
                Title = "Avatar: The Way of Water",
                Description = "Movie follows the journey of Jake Sully and Neytiri's newfound family of children",
                Duration = 179,
                PosterPath = "images/SoonInCinemas/avatar810x1200.jpeg",
                //TrailerPath = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/d9MyW72ELq0?si=Q8zXuPYn11JjjmB5\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>",
                Director_ID = Guid.Parse("0790E88F-C304-48FE-78E9-08DBE8F3E1C4")
            };
            myMovies.Add(Avatar);

            //Barbie
            var Barbie = new Movie()
            {
                Title = "Barbie",
                Description = "Set in the colorful Barbie Land, stereotypical Barbie lives a perfect life every single day. One day, she shows signs of being...a human. She decides to go to the Real World to find the cure in order to make herself perfect again.",
                Duration = 121,
                PosterPath = "images/SoonInCinemas/Barbie810x1200.jpg",
                Director_ID = Guid.Parse("22DC9E6F-1867-4C30-7905-08DBE8F3E1C4")

            };
            myMovies.Add(Barbie);

            //Batman
            var Batman = new Movie()
            {
                Title = "Batman: The Dark Knight",
                Description = "The plot follows the vigilante Batman, police lieutenant James Gordon, and district attorney Harvey Dent, who form an alliance to dismantle organized crime in Gotham City.",
                Duration = 149,
                PosterPath = "images/SoonInCinemas/Batman810x1200.jpg",
                Director_ID = Guid.Parse("6B8707BE-EBBA-4995-790C-08DBE8F3E1C4")
            };
            myMovies.Add(Batman);

            //Black Widow
            var BlackWidow = new Movie()
            {
                Title = "Black Widow",
                Description = "Romanoff on the run and forced to confront her past as a Russian spy before she became an Avenger.",
                Duration = 119,
                PosterPath = "images/SoonInCinemas/black-widow810x1200.jpg",
                Director_ID = Guid.Parse("6B8707BE-EBBA-4995-790C-08DBE8F3E1C4")
            };
            myMovies.Add(BlackWidow);

            //Cruella
            var Cruella = new Movie()
            {
                Title = "Cruella",
                Description = "The film revolves around Estella Miller, an aspiring fashion designer, as she explores the path that leads her to become a notorious up-and-coming fashion designer known as Cruella de Vil",
                Duration = 100,
                PosterPath = "images/SoonInCinemas/Cruella810x1200.jpg",
                Director_ID = Guid.Parse("D2B18D47-00E3-4120-791B-08DBE8F3E1C4")
            };
            myMovies.Add(Cruella);

            //Lord of The Rings
            var LOTR = new Movie()
            {
                Title = "The Lord of The Rings: Return of The King",
                Description = "Continuing the plot of the previous film, Frodo, Sam and Gollum are making their final way toward Mount Doom to destroy the One Ring",
                Duration = 180,
                PosterPath = "images/SoonInCinemas/LOTR810x1200.jpg",
                Director_ID = Guid.Parse("DF7DDDA4-17A5-49A4-7927-08DBE8F3E1C4")
            };
            myMovies.Add(LOTR);

            //The Nun
            var Nun = new Movie()
            {
                Title = "The Nun 2",
                Description = "1956 - France. A priest is murdered. An evil is spreading. The sequel to the worldwide smash hit follows Sister Irene as she once again comes face-to-face with Valak, the demon nun.",
                Duration = 130,
                PosterPath = "images/SoonInCinemas/Nun810x1200.jpg",
                Director_ID = Guid.Parse("D2B18D47-00E3-4120-791B-08DBE8F3E1C4")
            };
            myMovies.Add(Nun);

            //The Oppenheimer
            var Oppenheimer = new Movie()
            {
                Title = "Oppenheimer",
                Description = "The film chronicles the career of Oppenheimer, with the story predominantly focusing on his studies, his direction of the Manhattan Project during World War II, and his eventual fall from grace due to his 1954 security hearing.",
                Duration = 176,
                PosterPath = "images/SoonInCinemas/oppenheimer810x1200.jpg",
                Director_ID = Guid.Parse("6B8707BE-EBBA-4995-790C-08DBE8F3E1C4")
            };
            myMovies.Add(Oppenheimer);

            //Spiderman
            var Spiderman = new Movie()
            {
                Title = "Spider-Man: Across the spider-verse",
                Description = "Miles Morales catapults across the Multiverse, where he encounters a team of Spider-People charged with protecting its very existence. When the heroes clash on how to handle a new threat, Miles must redefine what it means to be a hero.",
                Duration = 154,
                PosterPath = "images/SoonInCinemas/Spiderman_across_the_spiderverse810x1200.jpg",
                Director_ID = Guid.Parse("EF6AD2E5-0FBD-4387-792C-08DBE8F3E1C4")
            };
            myMovies.Add(Spiderman);
            _appContext.AddRangeAsync();

            //Thor
            var Thor = new Movie()
            {
                Title = "Thor: Love and Thunder",
                Description = "Thor's retirement is interrupted by a galactic killer known as Gorr the God Butcher, who seeks the extinction of the gods. To combat the threat, Thor enlists the help of King Valkyrie, Korg and ex-girlfriend Jane Foster",
                Duration = 132,
                PosterPath = "images/SoonInCinemas/thor810x1200.jpeg",
                Director_ID = Guid.Parse("6B8707BE-EBBA-4995-790C-08DBE8F3E1C4")
            };
            myMovies.Add(Thor);

            //------EVENTS------
            //Wheel of Fortune and Fantasy
            var Fortune = new Movie()
            {
                Title = "Wheel of Fortune and Fantasy",
                Description = "An unexpected love triangle, a failed seduction trap and an encounter that results from a misunderstanding",
                Duration = 90,
                PosterPath = "images/Events/Asian810x1200.jpeg",
                Director_ID = Guid.Parse("D996ADA0-C6A8-4FCD-7949-08DBE8F3E1C4")
            };
            myMovies.Add(Fortune);

            //Barbenheimer
            var Barbenheimer = new Movie()
            {
                Title = "Barbenheimer",
                Description = "Cientist doll called Dr Bambi J Barbenheimer, living in the doll town Dolltopia, is bothered by how humans treat the dolls. So she goes on a mission to destroy the real world with a giant nuclear bomb.",
                Duration = 134,
                PosterPath = "images/Events/barbenheimer-810x1200.jpg",
                Director_ID = Guid.Parse("6B8707BE-EBBA-4995-790C-08DBE8F3E1C4")
            };
            myMovies.Add(Barbenheimer);

            //Fallenleaves
            var Fallenleaves = new Movie()
            {
                Title = "Fallen Leaves",
                Description = "Melancholy romantic comedy about two lonely souls who sleepwalk through life doing dead-end jobs.",
                Duration = 81,
                PosterPath = "images/Events/fallenleaves01-810x1200.jpg",
                Director_ID = Guid.Parse("5BDAD015-95BF-41F8-7960-08DBE8F3E1C4")
            };
            myMovies.Add(Fallenleaves);

            //Harlem
            var Harlem = new Movie()
            {
                Title = "Harlem",
                Description = "A group of four friends follow their dreams after graduating from college together.",
                Duration = 60,
                PosterPath = "images/Events/Harlem810x1200.jpg",
                Director_ID = Guid.Parse("062431DA-81F6-4F96-7975-08DBE8F3E1C4")
            };
            myMovies.Add(Harlem);

            //John Lewis
            var JohnLewis = new Movie()
            {
                Title = "John Lewis: Good Trouble",
                Description = "The film explores Georgia representative's, 60-plus years of social activism and legislative action on civil rights, voting rights, gun control, health care reform, and immigration.",
                Duration = 93,
                PosterPath = "images/Events/JohnLewis810x1200.jpg",
                Director_ID = Guid.Parse("2753FE53-EC10-4624-7983-08DBE8F3E1C4")
            };
            myMovies.Add(JohnLewis);

            //-------SLIDER-------
            //Slide 1
            var Slide1 = new Movie()
            {
                Title = "Mandalorian",
                Description = "Random",
                Duration = 54,
                PosterPath = "images/Slider/Mandalorian_1280_720.jpg",
                Director_ID = Guid.Parse("062431DA-81F6-4F96-7975-08DBE8F3E1C4")
            };
            myMovies.Add(Slide1);

            //Slide 2
            var Slide2 = new Movie()
            {
                Title = "MandalorianS3",
                Description = "Random",
                Duration = 56,
                PosterPath = "images/Slider/MandalorianS3_1280_720.jpg",
                Director_ID = Guid.Parse("18F4EA78-4EA1-4C70-78F0-08DBE8F3E1C4")
            };
            myMovies.Add(Slide2);

            //Slide 3
            var Slide3 = new Movie()
            {
                Title = "Pirates2",
                Description = "Random",
                Duration = 124,
                PosterPath = "images/Slider/Pirates2_1280_720.jpg",
                Director_ID = Guid.Parse("D01FE1C9-9364-4CF4-78F9-08DBE8F3E1C4")
            };
            myMovies.Add(Slide3);

            //Slide 4
            var Slide4 = new Movie()
            {
                Title = "Pirates",
                Description = "Random",
                Duration = 122,
                PosterPath = "images/Slider/Pirates_1280_720.jpg",
                Director_ID = Guid.Parse("5E1AAF66-AC55-4B6B-7901-08DBE8F3E1C4")
            };
            myMovies.Add(Slide4);

            //Slide 5
            var Slide5 = new Movie()
            {
                Title = "CSPO",
                Description = "Random",
                Duration = 122,
                PosterPath = "images/Slider/R2C3PO_1280_720.jpg",
                Director_ID = Guid.Parse("0C399BA6-32BD-4315-78F6-08DBE8F3E1C4")
            };
            myMovies.Add(Slide5);

            //Slide 6
            var Slide6 = new Movie()
            {
                Title = "ROTS1",
                Description = "Random",
                Duration = 122,
                PosterPath = "images/Slider/ROTS1280_720.jpg",
                Director_ID = Guid.Parse("22DC9E6F-1867-4C30-7905-08DBE8F3E1C4")
            };
            myMovies.Add(Slide6);
            //-------------------------------END OF ADDING NEW FILMS----------------------------//

            _appContext.AddRangeAsync();

            var movie = MovieGenerator.Generate(10);
            var director = DirectorGenerator.Generate(3);

            var actors = AccountGenerator.Generate(30);

            var showtime = ShowTimeGenerator.Generate(30);

            var hall = HallGenerator.Generate(10);
            var seat = SeatsGenerator.Generate(100);
            var account = AccountGenerator.Generate(30);

            var actorsmovie = ActorsInMovieGenerator.Generate(10);
            var category = CategoryGenerator.Generate(10);
            var categorymovie = CategoryMovieGenerator.Generate(30);
            var reservations = ReservationGenerator.Generate(100);

            _appContext.Movies.AddRange(movie);
            _appContext.Directors.AddRange(director);
          
           

            _appContext.Accounts.AddRange(account);
            
            _appContext.Seats.AddRange(seat);
            
            _appContext.Showtimes.AddRange(showtime);
            _appContext.Reservations.AddRange(reservations);
            
            _appContext.CinemaHalls.AddRange(hall);
            //_appContext.CinemaHalls.AddRange(actors);

  
            _appContext.ActorsInMovies.AddRange(actorsmovie);
            _appContext.Categories.AddRange(category);
            _appContext.CategoriesAndMovies.AddRange(categorymovie);
            _appContext.SaveChanges();

            return Task.CompletedTask;
        }

    }
    
}