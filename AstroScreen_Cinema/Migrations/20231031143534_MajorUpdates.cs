using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstroScreen_Cinema.Migrations
{
    /// <inheritdoc />
    public partial class MajorUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_actorsInMovies_Actors_Actor_ID",
                table: "actorsInMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_actorsInMovies_Movies_Movie_ID",
                table: "actorsInMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHalls_Movies_MovieFilm_ID",
                table: "CinemaHalls");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Directors_Director_ID",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Accounts_Account_ID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Seats_Seat_ID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_CinemaHalls_Hall_ID",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_CinemaHalls_Showtime_ID",
                table: "Showtimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Movies_Showtime_ID",
                table: "Showtimes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_Account_ID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_Seat_ID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_CinemaHalls_MovieFilm_ID",
                table: "CinemaHalls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_actorsInMovies",
                table: "actorsInMovies");

            migrationBuilder.DropColumn(
                name: "MovieFilm_ID",
                table: "CinemaHalls");

            migrationBuilder.DropColumn(
                name: "Movie_ID",
                table: "CinemaHalls");

            migrationBuilder.RenameTable(
                name: "actorsInMovies",
                newName: "ActorsInMovies");

            migrationBuilder.RenameColumn(
                name: "Customer_ID",
                table: "Reservations",
                newName: "PhoneNum");

            migrationBuilder.RenameIndex(
                name: "IX_actorsInMovies_Movie_ID",
                table: "ActorsInMovies",
                newName: "IX_ActorsInMovies_Movie_ID");

            migrationBuilder.AddColumn<int>(
                name: "Movie_ID",
                table: "Showtimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorsInMovies",
                table: "ActorsInMovies",
                columns: new[] { "Actor_ID", "Movie_ID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsInMovies_Actors_Actor_ID",
                table: "ActorsInMovies",
                column: "Actor_ID",
                principalTable: "Actors",
                principalColumn: "Actor_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsInMovies_Movies_Movie_ID",
                table: "ActorsInMovies",
                column: "Movie_ID",
                principalTable: "Movies",
                principalColumn: "Film_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Directors_Director_ID",
                table: "Movies",
                column: "Director_ID",
                principalTable: "Directors",
                principalColumn: "Director_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Accounts_Reservation_ID",
                table: "Reservations",
                column: "Reservation_ID",
                principalTable: "Accounts",
                principalColumn: "Account_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Seats_Reservation_ID",
                table: "Reservations",
                column: "Reservation_ID",
                principalTable: "Seats",
                principalColumn: "Seat_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_CinemaHalls_Hall_ID",
                table: "Seats",
                column: "Hall_ID",
                principalTable: "CinemaHalls",
                principalColumn: "Hall_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_CinemaHalls_Showtime_ID",
                table: "Showtimes",
                column: "Showtime_ID",
                principalTable: "CinemaHalls",
                principalColumn: "Hall_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Movies_Showtime_ID",
                table: "Showtimes",
                column: "Showtime_ID",
                principalTable: "Movies",
                principalColumn: "Film_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorsInMovies_Actors_Actor_ID",
                table: "ActorsInMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsInMovies_Movies_Movie_ID",
                table: "ActorsInMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Directors_Director_ID",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Accounts_Reservation_ID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Seats_Reservation_ID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_CinemaHalls_Hall_ID",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_CinemaHalls_Showtime_ID",
                table: "Showtimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Movies_Showtime_ID",
                table: "Showtimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorsInMovies",
                table: "ActorsInMovies");

            migrationBuilder.DropColumn(
                name: "Movie_ID",
                table: "Showtimes");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "ActorsInMovies",
                newName: "actorsInMovies");

            migrationBuilder.RenameColumn(
                name: "PhoneNum",
                table: "Reservations",
                newName: "Customer_ID");

            migrationBuilder.RenameIndex(
                name: "IX_ActorsInMovies_Movie_ID",
                table: "actorsInMovies",
                newName: "IX_actorsInMovies_Movie_ID");

            migrationBuilder.AddColumn<int>(
                name: "MovieFilm_ID",
                table: "CinemaHalls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Movie_ID",
                table: "CinemaHalls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_actorsInMovies",
                table: "actorsInMovies",
                columns: new[] { "Actor_ID", "Movie_ID" });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<int>(type: "int", nullable: false),
                    Reservation_ID = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_ID);
                    table.ForeignKey(
                        name: "FK_Customers_Reservations_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "Reservations",
                        principalColumn: "Reservation_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Account_ID",
                table: "Reservations",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Seat_ID",
                table: "Reservations",
                column: "Seat_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHalls_MovieFilm_ID",
                table: "CinemaHalls",
                column: "MovieFilm_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_actorsInMovies_Actors_Actor_ID",
                table: "actorsInMovies",
                column: "Actor_ID",
                principalTable: "Actors",
                principalColumn: "Actor_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_actorsInMovies_Movies_Movie_ID",
                table: "actorsInMovies",
                column: "Movie_ID",
                principalTable: "Movies",
                principalColumn: "Film_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHalls_Movies_MovieFilm_ID",
                table: "CinemaHalls",
                column: "MovieFilm_ID",
                principalTable: "Movies",
                principalColumn: "Film_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Directors_Director_ID",
                table: "Movies",
                column: "Director_ID",
                principalTable: "Directors",
                principalColumn: "Director_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Accounts_Account_ID",
                table: "Reservations",
                column: "Account_ID",
                principalTable: "Accounts",
                principalColumn: "Account_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Seats_Seat_ID",
                table: "Reservations",
                column: "Seat_ID",
                principalTable: "Seats",
                principalColumn: "Seat_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_CinemaHalls_Hall_ID",
                table: "Seats",
                column: "Hall_ID",
                principalTable: "CinemaHalls",
                principalColumn: "Hall_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_CinemaHalls_Showtime_ID",
                table: "Showtimes",
                column: "Showtime_ID",
                principalTable: "CinemaHalls",
                principalColumn: "Hall_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Movies_Showtime_ID",
                table: "Showtimes",
                column: "Showtime_ID",
                principalTable: "Movies",
                principalColumn: "Film_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
