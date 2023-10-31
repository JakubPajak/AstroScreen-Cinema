﻿// <auto-generated />
using System;
using AstroScreen_Cinema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AstroScreen_Cinema.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20231031172044_Krwawica")]
    partial class Krwawica
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AstroScreen_Cinema.Models.Account", b =>
                {
                    b.Property<int>("Account_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Account_ID"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNum")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Account_ID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Actors", b =>
                {
                    b.Property<int>("Actor_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Actor_ID"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Actor_ID");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.ActorsInMovies", b =>
                {
                    b.Property<int>("Actor_ID")
                        .HasColumnType("int");

                    b.Property<int>("Movie_ID")
                        .HasColumnType("int");

                    b.HasKey("Actor_ID", "Movie_ID");

                    b.HasIndex("Movie_ID");

                    b.ToTable("ActorsInMovies");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Categories", b =>
                {
                    b.Property<int>("Categorie_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Categorie_ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Categorie_ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.CategoriesAndMovies", b =>
                {
                    b.Property<int>("Category_ID")
                        .HasColumnType("int");

                    b.Property<int>("Movie_ID")
                        .HasColumnType("int");

                    b.HasKey("Category_ID", "Movie_ID");

                    b.HasIndex("Movie_ID");

                    b.ToTable("CategoriesAndMovies");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.CinemaHall", b =>
                {
                    b.Property<int>("Hall_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Hall_ID"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("RowNum")
                        .HasColumnType("int");

                    b.Property<int>("SeatNum")
                        .HasColumnType("int");

                    b.HasKey("Hall_ID");

                    b.ToTable("CinemaHalls");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Directors", b =>
                {
                    b.Property<int>("Director_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Director_ID"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Director_ID");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Movie", b =>
                {
                    b.Property<int>("Film_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Film_ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Director_ID")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("Showtime_ID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Film_ID");

                    b.HasIndex("Director_ID");

                    b.HasIndex("Showtime_ID")
                        .IsUnique();

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Reservation", b =>
                {
                    b.Property<int>("Reservation_ID")
                        .HasColumnType("int");

                    b.Property<int>("Account_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRegistered")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNum")
                        .HasColumnType("int");

                    b.Property<DateTime>("Reservation_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Seat_ID")
                        .HasColumnType("int");

                    b.Property<int>("Showtime_ID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Reservation_ID");

                    b.HasIndex("Account_ID");

                    b.HasIndex("Seat_ID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Seats", b =>
                {
                    b.Property<int>("Seat_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Seat_ID"));

                    b.Property<int>("Hall_ID")
                        .HasColumnType("int");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit");

                    b.Property<int>("RowNum")
                        .HasColumnType("int");

                    b.Property<int>("SeatNum")
                        .HasColumnType("int");

                    b.HasKey("Seat_ID");

                    b.HasIndex("Hall_ID");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Showtime", b =>
                {
                    b.Property<int>("Showtime_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<int>("Hall_ID")
                        .HasColumnType("int");

                    b.Property<int>("Movie_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Showtime_ID");

                    b.ToTable("Showtimes");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.ActorsInMovies", b =>
                {
                    b.HasOne("AstroScreen_Cinema.Models.Actors", "Actor")
                        .WithMany("Movies")
                        .HasForeignKey("Actor_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AstroScreen_Cinema.Models.Movie", "Movie")
                        .WithMany("Actors")
                        .HasForeignKey("Movie_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.CategoriesAndMovies", b =>
                {
                    b.HasOne("AstroScreen_Cinema.Models.Categories", "Categories")
                        .WithMany("Movies")
                        .HasForeignKey("Category_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AstroScreen_Cinema.Models.Movie", "Movies")
                        .WithMany("Categories")
                        .HasForeignKey("Movie_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Movie", b =>
                {
                    b.HasOne("AstroScreen_Cinema.Models.Directors", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("Director_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AstroScreen_Cinema.Models.Showtime", "Showtime")
                        .WithOne("Movie")
                        .HasForeignKey("AstroScreen_Cinema.Models.Movie", "Showtime_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Director");

                    b.Navigation("Showtime");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Reservation", b =>
                {
                    b.HasOne("AstroScreen_Cinema.Models.Account", "Account")
                        .WithMany("Reservations")
                        .HasForeignKey("Account_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AstroScreen_Cinema.Models.Showtime", "Showtime")
                        .WithMany("Reservations")
                        .HasForeignKey("Reservation_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AstroScreen_Cinema.Models.Seats", "Seat")
                        .WithMany("Reservations")
                        .HasForeignKey("Seat_ID")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Seat");

                    b.Navigation("Showtime");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Seats", b =>
                {
                    b.HasOne("AstroScreen_Cinema.Models.CinemaHall", "CinemaHall")
                        .WithMany("Seats")
                        .HasForeignKey("Hall_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CinemaHall");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Showtime", b =>
                {
                    b.HasOne("AstroScreen_Cinema.Models.CinemaHall", "CinemaHall")
                        .WithMany("Showtimes")
                        .HasForeignKey("Showtime_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CinemaHall");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Account", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Actors", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Categories", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.CinemaHall", b =>
                {
                    b.Navigation("Seats");

                    b.Navigation("Showtimes");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Directors", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Movie", b =>
                {
                    b.Navigation("Actors");

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Seats", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Showtime", b =>
                {
                    b.Navigation("Movie")
                        .IsRequired();

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
