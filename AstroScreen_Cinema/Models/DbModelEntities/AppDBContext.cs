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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //	optionsBuilder.UseLazyLoadingProxies();
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly)


            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Account)
                .WithMany(a => a.Reservations)
                .HasForeignKey(k => k.Account_ID)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Reservation>()
                .HasOne(s => s.Seat)
                .WithMany(r => r.Reservations)
                .HasForeignKey(k => k.Seat_ID)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Reservation>()
                .HasOne(sh => sh.Showtime)
                .WithMany(r => r.Reservations)
                .HasForeignKey(k => k.Showtime_ID);


            modelBuilder.Entity<Showtime>()
                .HasOne(m => m.Movie)
                .WithMany(m => m.Showtimes)
                .HasForeignKey(k => k.Movie_ID);

            modelBuilder.Entity<CinemaHall>()
                .HasMany(s => s.Seats)
                .WithOne(h => h.CinemaHall)
                .HasForeignKey(k => k.Hall_ID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CinemaHall>()
                .HasMany(sh => sh.Showtimes)
                .WithOne(h => h.CinemaHall)
                .HasForeignKey(k => k.Hall_ID)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Directors>()
                .HasMany(m => m.Movies)
                .WithOne(d => d.Director)
                .HasForeignKey(k => k.Director_ID)
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

            //base.OnModelCreating(modelBuilder);
        }

    }
}