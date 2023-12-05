using System;
using AstroScreen_Cinema.Models;

namespace AstroScreen_Cinema.DataSeed
{
	public class MyMovieGen
	{
        private readonly AppDBContext _appContext;

        public MyMovieGen(AppDBContext appContext)
		{
            _appContext = appContext;
		}

		public List<Movie> GenerateMovie()
		{
            var myMovies = new List<Movie> { };

            #region Soon In Cinemas / Also now showing
            //------Soon In Cinemas / Also now showing------
            //Avatar
            var Avatar = new Movie()
            {
                Title = "Avatar: The Way of Water",
                Description = "Movie follows the journey of Jake Sully and Neytiri's newfound family of children",
                Duration = 179,
                PosterPath = "images/SoonInCinemas/avatar810x1200.jpeg",
                //TrailerPath = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/d9MyW72ELq0?si=Q8zXuPYn11JjjmB5\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>",
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("e1a50987-95c7-4739-46fc-08dbde026de1")))
            };
            myMovies.Add(Avatar);

            ////Barbie
            var Barbie = new Movie()
            {
                Title = "Barbie",
                Description = "Set in the colorful Barbie Land, stereotypical Barbie lives a perfect life every single day. One day, she shows signs of being...a human. She decides to go to the Real World to find the cure in order to make herself perfect again.",
                Duration = 121,
                PosterPath = "images/SoonInCinemas/Barbie810x1200.jpg",
                //Director_ID = Guid.Parse("e1a50987-95c7-4739-46fc-08dbde026de1"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("e1a50987-95c7-4739-46fc-08dbde026de1")))
            };
            myMovies.Add(Barbie);


            ////await _appContext.AddRangeAsync(myMovies);
            ////await _appContext.SaveChangesAsync();

            ////Batman
            var Batman = new Movie()
            {
                Title = "Batman: The Dark Knight",
                Description = "The plot follows the vigilante Batman, police lieutenant James Gordon, and district attorney Harvey Dent, who form an alliance to dismantle organized crime in Gotham City.",
                Duration = 149,
                PosterPath = "images/SoonInCinemas/Batman810x1200.jpg",
                //Director_ID = Guid.Parse("e1a50987-95c7-4739-46fc-08dbde026de1"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("e1a50987-95c7-4739-46fc-08dbde026de1")))
            };
            myMovies.Add(Batman);

            ////Black Widow
            var BlackWidow = new Movie()
            {
                Title = "Black Widow",
                Description = "Romanoff on the run and forced to confront her past as a Russian spy before she became an Avenger.",
                Duration = 119,
                PosterPath = "images/SoonInCinemas/black-widow810x1200.jpg",
                //Director_ID = Guid.Parse("e1a50987-95c7-4739-46fc-08dbde026de1"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("e1a50987-95c7-4739-46fc-08dbde026de1")))
            };
            myMovies.Add(BlackWidow);

            ////Cruella
            var Cruella = new Movie()
            {
                Title = "Cruella",
                Description = "The film revolves around Estella Miller, an aspiring fashion designer, as she explores the path that leads her to become a notorious up-and-coming fashion designer known as Cruella de Vil",
                Duration = 100,
                PosterPath = "images/SoonInCinemas/Cruella810x1200.jpg",
                //Director_ID = Guid.Parse("01076649-907b-46c6-46fe-08dbde026de1"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("01076649-907b-46c6-46fe-08dbde026de1")))
            };
            myMovies.Add(Cruella);

            ////Lord of The Rings
            var LOTR = new Movie()
            {
                Title = "The Lord of The Rings: Return of The King",
                Description = "Continuing the plot of the previous film, Frodo, Sam and Gollum are making their final way toward Mount Doom to destroy the One Ring",
                Duration = 180,
                PosterPath = "images/SoonInCinemas/LOTR810x1200.jpg",
                //Director_ID = Guid.Parse("01076649-907b-46c6-46fe-08dbde026de1"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("01076649-907b-46c6-46fe-08dbde026de1")))
            };
            myMovies.Add(LOTR);

            ////The Nun
            var Nun = new Movie()
            {
                Title = "The Nun 2",
                Description = "1956 - France. A priest is murdered. An evil is spreading. The sequel to the worldwide smash hit follows Sister Irene as she once again comes face-to-face with Valak, the demon nun.",
                Duration = 130,
                PosterPath = "images/SoonInCinemas/Nun810x1200.jpg",
                //Director_ID = Guid.Parse("01076649-907b-46c6-46fe-08dbde026de1"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("01076649-907b-46c6-46fe-08dbde026de1")))
            };
            myMovies.Add(Nun);

            ////The Oppenheimer
            var Oppenheimer = new Movie()
            {
                Title = "Oppenheimer",
                Description = "The film chronicles the career of Oppenheimer, with the story predominantly focusing on his studies, his direction of the Manhattan Project during World War II, and his eventual fall from grace due to his 1954 security hearing.",
                Duration = 176,
                PosterPath = "images/SoonInCinemas/oppenheimer810x1200.jpg",
                //Director_ID = Guid.Parse("620cafb0-729e-4b5d-4700-08dbde026de1"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("620cafb0-729e-4b5d-4700-08dbde026de1")))
            };
            myMovies.Add(Oppenheimer);

            ////Spiderman
            var Spiderman = new Movie()
            {
                Title = "Spider-Man: Across the spider-verse",
                Description = "Miles Morales catapults across the Multiverse, where he encounters a team of Spider-People charged with protecting its very existence. When the heroes clash on how to handle a new threat, Miles must redefine what it means to be a hero.",
                Duration = 154,
                PosterPath = "images/SoonInCinemas/Spiderman_across_the_spiderverse810x1200.jpg",
                //Director_ID = Guid.Parse("620cafb0-729e-4b5d-4700-08dbde026de1"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("620cafb0-729e-4b5d-4700-08dbde026de1")))
            };
            myMovies.Add(Spiderman);
            //await _appContext.AddRangeAsync();

            ////Thor
            var Thor = new Movie()
            {
                Title = "Thor: Love and Thunder",
                Description = "Thor's retirement is interrupted by a galactic killer known as Gorr the God Butcher, who seeks the extinction of the gods. To combat the threat, Thor enlists the help of King Valkyrie, Korg and ex-girlfriend Jane Foster",
                Duration = 132,
                PosterPath = "images/SoonInCinemas/thor810x1200.jpeg",
                //Director_ID = Guid.Parse("620cafb0-729e-4b5d-4700-08dbde026de1"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("620cafb0-729e-4b5d-4700-08dbde026de1")))

            };
            myMovies.Add(Thor);
            #endregion

            #region ------EVENTS------
            //------EVENTS------
            //Wheel of Fortune and Fantasy
            var Fortune = new Movie()
            {
                Title = "Wheel of Fortune and Fantasy",
                Description = "An unexpected love triangle, a failed seduction trap and an encounter that results from a misunderstanding",
                Duration = 90,
                PosterPath = "images/Events/Asian810x1200.jpeg",
                //Director_ID = Guid.Parse("04bca373-e204-4366-4702-08dbde026de1"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("04bca373-e204-4366-4702-08dbde026de1")))
            };
            myMovies.Add(Fortune);


            //Barbenheimer
            var Barbenheimer = new Movie()
            {
                Title = "Barbenheimer",
                Description = "Cientist doll called Dr Bambi J Barbenheimer, living in the doll town Dolltopia, is bothered by how humans treat the dolls. So she goes on a mission to destroy the real world with a giant nuclear bomb.",
                Duration = 134,
                PosterPath = "images/Events/barbenheimer-810x1200.jpg",
                //Director_ID = Guid.Parse("04bca373-e204-4366-4702-08dbde026de1"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("db04cebf-074b-4ff9-e347-08dbf5004f72")))
            };
            myMovies.Add(Barbenheimer);

            //Fallenleaves
            var Fallenleaves = new Movie()
            {
                Title = "Fallen Leaves",
                Description = "Melancholy romantic comedy about two lonely souls who sleepwalk through life doing dead-end jobs.",
                Duration = 81,
                PosterPath = "images/Events/fallenleaves01-810x1200.jpg",
                //Director_ID = Guid.Parse("04bca373-e204-4366-4702-08dbde026de1"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("04bca373-e204-4366-4702-08dbde026de1")))
            };
            myMovies.Add(Fallenleaves);


            //Harlem
            var Harlem = new Movie()
            {
                Title = "Harlem",
                Description = "A group of four friends follow their dreams after graduating from college together.",
                Duration = 60,
                PosterPath = "images/Events/Harlem810x1200.jpg",
                //Director_ID = Guid.Parse("336852fa-28e5-44e6-4704-08dbde026de1"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("04bca373-e204-4366-4702-08dbde026de1")))
            };
            myMovies.Add(Harlem);



            //John Lewis
            var JohnLewis = new Movie()
            {
                Title = "John Lewis: Good Trouble",
                Description = "The film explores Georgia representative's, 60-plus years of social activism and legislative action on civil rights, voting rights, gun control, health care reform, and immigration.",
                Duration = 93,
                PosterPath = "images/Events/JohnLewis810x1200.jpg",
                //Director_ID = Guid.Parse("336852fa-28e5-44e6-4704-08dbde026de1"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("1bcec000-fffb-49bb-86e6-08dbde0a2fe7")))
            };
            myMovies.Add(JohnLewis);

            #endregion

            #region -------SLIDER-------
            //-------SLIDER-------
            //Slide 1
            var Slide1 = new Movie()
            {
                Title = "Mandalorian",
                Description = "Random",
                Duration = 54,
                PosterPath = "images/Slider/Mandalorian_1280_720.jpg",
                //Director_ID = Guid.Parse("336852fa-28e5-44e6-4704-08dbde026de1"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("1bcec000-fffb-49bb-86e6-08dbde0a2fe7")))
            };
            myMovies.Add(Slide1);

            //Slide 2
            var Slide2 = new Movie()
            {
                Title = "MandalorianS3",
                Description = "Random",
                Duration = 56,
                PosterPath = "images/Slider/MandalorianS3_1280_720.jpg",
                //Director_ID = Guid.Parse("27683593-b45e-420a-08f7-08dbde030165"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("6fbb2853-4279-49f0-86e8-08dbde0a2fe7")))
            };
            myMovies.Add(Slide2);


            //Slide 3
            var Slide3 = new Movie()
            {
                Title = "Pirates2",
                Description = "Random",
                Duration = 124,
                PosterPath = "images/Slider/Pirates2_1280_720.jpg",
                //Director_ID = Guid.Parse("27683593-b45e-420a-08f7-08dbde030165"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID.Equals(Guid.Parse("1be7495b-b890-4e84-86ea-08dbde0a2fe7")))
            };
            myMovies.Add(Slide3);

            //Slide 4
            var Slide4 = new Movie()
            {
                Title = "Pirates",
                Description = "Random",
                Duration = 122,
                PosterPath = "images/Slider/Pirates_1280_720.jpg",
                // Director_ID = Guid.Parse("062b324b-ff9b-49b7-46fb-08dbde026de1"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID == Guid.Parse("acafe3e9-8e71-43b6-86ec-08dbde0a2fe7"))
            };
            myMovies.Add(Slide4);

            //Slide 5
            var Slide5 = new Movie()
            {
                Title = "CSPO",
                Description = "Random",
                Duration = 122,
                PosterPath = "images/Slider/R2C3PO_1280_720.jpg",
                //Director_ID = Guid.Parse("aed9b210-5be7-4fd3-08f4-08dbde030165"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID == Guid.Parse("b01a3c6f-2cae-4b55-86e5-08dbde0a2fe7"))
            };
            myMovies.Add(Slide5);

            //Slide 6
            var Slide6 = new Movie()
            {
                Title = "ROTS1",
                Description = "Random",
                Duration = 122,
                PosterPath = "images/Slider/ROTS1280_720.jpg",
                //Director_ID = Guid.Parse("aed9b210-5be7-4fd3-08f4-08dbde030165"),
                Director = _appContext.Directors.FirstOrDefault(d => d.Director_ID == Guid.Parse("5d21d7aa-4757-47e0-7f41-08dbde07d180"))
            };
            myMovies.Add(Slide6);

            #endregion

            return myMovies;
        }
    }
}

