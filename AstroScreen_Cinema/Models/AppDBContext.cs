using System;
using Microsoft.EntityFrameworkCore;

namespace AstroScreen_Cinema.Models
{
	public class AppDBContext : DbContext
	{
		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		{
		}

		public DbSet<Account> Accounts { get; set; }

		public DbSet<Actors> Actors { get; set; }

		public DbSet<ActorsInMovies> actorsInMovies { get; set; }

		public DbSet<Categories> Categories { get; set; }

		public DbSet<CategoriesAndMovies> CategoriesAndMovies { get; set; }

		public DbSet<CinemaHall> CinemaHalls { get; set; }

		public DbSet<Customer> Customers { get; set; }

		public DbSet<Directors> Directors { get; set; }

		public DbSet<Movie> Movies { get; set; }

		public DbSet<Reservation> Reservations { get; set; }

		public DbSet<Seats> Seats { get; set; }

		public DbSet<Showtime> Showtimes { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Reservation>()
				.HasOne(r => r.Account)
				.WithMany(a => a.Reservations)
				.HasForeignKey(k => k.Account_ID);


			modelBuilder.Entity<Reservation>()
				.HasOne(r => r.Customer)
				.WithOne(c => c.Reservation)
				.HasForeignKey<Customer>(k => k.Customer_ID);

			modelBuilder.Entity<Reservation>()
				.HasOne(r => r.Seat)
				.WithOne(s => s.Reservation)
				.HasForeignKey<Seats>(k => k.Reservation_ID);

			modelBuilder.Entity<Showtime>()
				.HasMany(r => r.Reservations)
				.WithOne(sh => sh.Showtime)
				.HasForeignKey(k => k.Reservation_ID);

			modelBuilder.Entity<CinemaHall>()
				.HasMany(s => s.Seats)
				.WithOne(h => h.CinemaHall)
				.HasForeignKey(k => k.Hall_ID);

			modelBuilder.Entity<CinemaHall>()
				.HasMany(sh => sh.Showtimes)
				.WithOne(h => h.CinemaHall)
				.HasForeignKey(k => k.Showtime_ID);

			modelBuilder.Entity<Movie>()
				.HasOne(d => d.Director)
				.WithMany(m => m.Movies)
				.HasForeignKey(k => k.Director_ID);

			modelBuilder.Entity<Movie>()
				.HasOne(sh => sh.Showtime)
				.WithOne(m => m.Movie)
				.HasForeignKey<Showtime>(sh => sh.Movie_ID);
		}
				
    }
}

