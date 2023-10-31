using System;
using Microsoft.EntityFrameworkCore;

namespace AstroScreen_Cinema.Models
{
	public class AppDBContext : DbContext
	{

		//private readonly string ConnectionStringMAC = "Server=localhost,1433;Database=AstroCinema_DB;User=sa; Password=reallyStrongPwd123;TrustServerCertificate=true;";
		//private readonly string ConnectionStringWIN = "";

		public DbSet<Account> Accounts { get; set; }

		public DbSet<Actors> Actors { get; set; }

		public DbSet<ActorsInMovies> ActorsInMovies { get; set; }

		public DbSet<Categories> Categories { get; set; }

		public DbSet<CategoriesAndMovies> CategoriesAndMovies { get; set; }

		public DbSet<CinemaHall> CinemaHalls { get; set; }

		public DbSet<Directors> Directors { get; set; }

		public DbSet<Movie> Movies { get; set; }

		public DbSet<Reservation> Reservations { get; set; }

		public DbSet<Seats> Seats { get; set; }

		public DbSet<Showtime> Showtimes { get; set; }


		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		{
		}


		//public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		//{
		//}


		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer("ConnectionStringMAC")
		//		.EnableSensitiveDataLogging();
		//}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			//modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);


			modelBuilder.Entity<Reservation>()
				.HasOne(r => r.Account)
				.WithMany(a => a.Reservations)
				.HasForeignKey(k => k.Account_ID)
				.OnDelete(DeleteBehavior.NoAction);


			modelBuilder.Entity<Reservation>()
				.HasOne(s => s.Seat) 
				.WithMany(r => r.Reservations)
				.HasForeignKey(k => k.Seat_ID)
				.OnDelete(DeleteBehavior.ClientNoAction);


			modelBuilder.Entity<Reservation>()
				.HasOne(sh => sh.Showtime)
				.WithMany(r => r.Reservations)
				.HasForeignKey(k => k.Showtime_ID)
				.OnDelete(DeleteBehavior.NoAction);


			modelBuilder.Entity<Account>()
				.HasMany(r => r.Reservations)
				.WithOne(a => a.Account)
				.HasForeignKey(k => k.Reservation_ID)
				.OnDelete(DeleteBehavior.Cascade);


			modelBuilder.Entity<Seats>()
				.HasMany(r => r.Reservations)
				.WithOne(s => s.Seat)
				.HasForeignKey(k => k.Reservation_ID)
				.OnDelete(DeleteBehavior.NoAction);


			modelBuilder.Entity<Seats>()
				.HasOne(ch => ch.CinemaHall)
				.WithMany(s => s.Seats)
				.HasForeignKey(k => k.Hall_ID)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Showtime>()
				.HasMany(r => r.Reservations)
				.WithOne(sh => sh.Showtime)
				.HasForeignKey(k => k.Reservation_ID)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Showtime>()
				.HasOne(ch => ch.CinemaHall)
				.WithMany(sh => sh.Showtimes)
				.HasForeignKey(k => k.Hall_ID)
				.OnDelete(DeleteBehavior.NoAction);


			modelBuilder.Entity<Showtime>()
				.HasOne(m => m.Movie)
				.WithOne(sh => sh.Showtime)
				.HasForeignKey<Movie>(k => k.Showtime_ID)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<CinemaHall>()
				.HasMany(s => s.Seats)
				.WithOne(h => h.CinemaHall)
				.HasForeignKey(k => k.Hall_ID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CinemaHall>()
				.HasMany(sh => sh.Showtimes)
				.WithOne(h => h.CinemaHall)
				.HasForeignKey(k => k.Showtime_ID)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Movie>()
				.HasOne(d => d.Director)
				.WithMany(m => m.Movies)
				.HasForeignKey(k => k.Director_ID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Movie>()
				.HasOne(m => m.Showtime)
				.WithOne(sh => sh.Movie)
				.HasForeignKey<Showtime>(sh => sh.Showtime_ID)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Movie>()
				.HasMany(a => a.Actors)
				.WithOne(m => m.Movie)
				.HasForeignKey(k => k.Movie_ID)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<ActorsInMovies>()
				.HasKey(k => new { k.Actor_ID, k.Movie_ID });

			modelBuilder.Entity<ActorsInMovies>()
				.HasOne(a => a.Actor)
				.WithMany(m => m.Movies)
				.HasForeignKey(k => k.Actor_ID);

			modelBuilder.Entity<ActorsInMovies>()
				.HasOne(m => m.Movie)
				.WithMany(a => a.Actors)
				.HasForeignKey(k => k.Movie_ID);

			modelBuilder.Entity<CategoriesAndMovies>()
				.HasKey(k => new { k.Category_ID, k.Movie_ID });

			modelBuilder.Entity<CategoriesAndMovies>()
				.HasOne(c => c.Categories)
				.WithMany(m => m.Movies)
				.HasForeignKey(k => k.Category_ID);

			modelBuilder.Entity<CategoriesAndMovies>()
				.HasOne(m => m.Movies)
				.WithMany(c => c.Categories)
				.HasForeignKey(k => k.Movie_ID);
		}
				
    }
}

