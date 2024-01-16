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
    [Migration("20240104190626_ReservationModified")]
    partial class ReservationModified
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
                    b.Property<Guid>("Account_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                    b.Property<Guid>("Actor_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Actor_ID");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.ActorsInMovies", b =>
                {
                    b.Property<Guid>("Actor_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Movie_ID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Actor_ID", "Movie_ID");

                    b.HasIndex("Movie_ID");

                    b.ToTable("ActorsInMovies");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Categories", b =>
                {
                    b.Property<Guid>("Categorie_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                    b.Property<Guid>("Category_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Movie_ID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Category_ID", "Movie_ID");

                    b.HasIndex("Movie_ID");

                    b.ToTable("CategoriesAndMovies");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.CinemaHall", b =>
                {
                    b.Property<Guid>("Hall_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                    b.Property<Guid>("Director_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Director_ID");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Movie", b =>
                {
                    b.Property<Guid>("Film_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Director_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("PosterPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Film_ID");

                    b.HasIndex("Director_ID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Reservation", b =>
                {
                    b.Property<Guid>("Reservation_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Account_ID")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid>("Showtime_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Reservation_ID");

                    b.HasIndex("Account_ID");

                    b.HasIndex("Showtime_ID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Seats", b =>
                {
                    b.Property<Guid>("Seat_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Hall_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit");

                    b.Property<Guid>("Reservation_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RowNum")
                        .HasColumnType("int");

                    b.Property<int>("SeatNum")
                        .HasColumnType("int");

                    b.HasKey("Seat_ID");

                    b.HasIndex("Hall_ID");

                    b.HasIndex("Reservation_ID");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Showtime", b =>
                {
                    b.Property<Guid>("Showtime_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Hall_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Movie_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Showtime_ID");

                    b.HasIndex("Hall_ID");

                    b.HasIndex("Movie_ID");

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
                        .OnDelete(DeleteBehavior.Cascade)
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

                    b.Navigation("Director");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Reservation", b =>
                {
                    b.HasOne("AstroScreen_Cinema.Models.Account", "Account")
                        .WithMany("Reservations")
                        .HasForeignKey("Account_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AstroScreen_Cinema.Models.Showtime", "Showtime")
                        .WithMany("Reservations")
                        .HasForeignKey("Showtime_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Showtime");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Seats", b =>
                {
                    b.HasOne("AstroScreen_Cinema.Models.CinemaHall", "CinemaHall")
                        .WithMany("Seats")
                        .HasForeignKey("Hall_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AstroScreen_Cinema.Models.Reservation", "Reservation")
                        .WithMany("Seats")
                        .HasForeignKey("Reservation_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CinemaHall");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Showtime", b =>
                {
                    b.HasOne("AstroScreen_Cinema.Models.CinemaHall", "CinemaHall")
                        .WithMany("Showtimes")
                        .HasForeignKey("Hall_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AstroScreen_Cinema.Models.Movie", "Movie")
                        .WithMany("Showtimes")
                        .HasForeignKey("Movie_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CinemaHall");

                    b.Navigation("Movie");
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

                    b.Navigation("Showtimes");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Reservation", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("AstroScreen_Cinema.Models.Showtime", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}