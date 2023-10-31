using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstroScreen_Cinema.Migrations
{
    /// <inheritdoc />
    public partial class Krwawica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Accounts_Reservation_ID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Seats_Reservation_ID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Movies_Showtime_ID",
                table: "Showtimes");

            migrationBuilder.DropColumn(
                name: "CategoriesAndFilms_ID",
                table: "CategoriesAndMovies");

            migrationBuilder.DropColumn(
                name: "ActorsFilms_ID",
                table: "ActorsInMovies");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Account_ID",
                table: "Reservations",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Seat_ID",
                table: "Reservations",
                column: "Seat_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Showtime_ID",
                table: "Movies",
                column: "Showtime_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Showtimes_Showtime_ID",
                table: "Movies",
                column: "Showtime_ID",
                principalTable: "Showtimes",
                principalColumn: "Showtime_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Accounts_Account_ID",
                table: "Reservations",
                column: "Account_ID",
                principalTable: "Accounts",
                principalColumn: "Account_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Seats_Seat_ID",
                table: "Reservations",
                column: "Seat_ID",
                principalTable: "Seats",
                principalColumn: "Seat_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Showtimes_Showtime_ID",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Accounts_Account_ID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Seats_Seat_ID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_Account_ID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_Seat_ID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Movies_Showtime_ID",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesAndFilms_ID",
                table: "CategoriesAndMovies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActorsFilms_ID",
                table: "ActorsInMovies",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "FK_Showtimes_Movies_Showtime_ID",
                table: "Showtimes",
                column: "Showtime_ID",
                principalTable: "Movies",
                principalColumn: "Film_ID");
        }
    }
}
