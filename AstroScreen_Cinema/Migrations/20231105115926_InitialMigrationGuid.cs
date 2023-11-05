using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstroScreen_Cinema.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Account_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Account_ID);
                });

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Actor_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Actor_ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Categorie_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Categorie_ID);
                });

            migrationBuilder.CreateTable(
                name: "CinemaHalls",
                columns: table => new
                {
                    Hall_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumOfSeats = table.Column<int>(type: "int", nullable: false),
                    RowNum = table.Column<int>(type: "int", nullable: false),
                    SeatNum = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHalls", x => x.Hall_ID);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Director_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Director_ID);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Seat_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowNum = table.Column<int>(type: "int", nullable: false),
                    SeatNum = table.Column<int>(type: "int", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false),
                    Hall_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Seat_ID);
                    table.ForeignKey(
                        name: "FK_Seats_CinemaHalls_Hall_ID",
                        column: x => x.Hall_ID,
                        principalTable: "CinemaHalls",
                        principalColumn: "Hall_ID");
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Film_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Director_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Film_ID);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_Director_ID",
                        column: x => x.Director_ID,
                        principalTable: "Directors",
                        principalColumn: "Director_ID");
                });

            migrationBuilder.CreateTable(
                name: "ActorsInMovies",
                columns: table => new
                {
                    Actor_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Movie_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorsInMovies", x => new { x.Actor_ID, x.Movie_ID });
                    table.ForeignKey(
                        name: "FK_ActorsInMovies_Actors_Actor_ID",
                        column: x => x.Actor_ID,
                        principalTable: "Actors",
                        principalColumn: "Actor_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorsInMovies_Movies_Movie_ID",
                        column: x => x.Movie_ID,
                        principalTable: "Movies",
                        principalColumn: "Film_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesAndMovies",
                columns: table => new
                {
                    Category_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Movie_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesAndMovies", x => new { x.Category_ID, x.Movie_ID });
                    table.ForeignKey(
                        name: "FK_CategoriesAndMovies_Categories_Category_ID",
                        column: x => x.Category_ID,
                        principalTable: "Categories",
                        principalColumn: "Categorie_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesAndMovies_Movies_Movie_ID",
                        column: x => x.Movie_ID,
                        principalTable: "Movies",
                        principalColumn: "Film_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Showtimes",
                columns: table => new
                {
                    Showtime_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hall_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Movie_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showtimes", x => x.Showtime_ID);
                    table.ForeignKey(
                        name: "FK_Showtimes_CinemaHalls_Hall_ID",
                        column: x => x.Hall_ID,
                        principalTable: "CinemaHalls",
                        principalColumn: "Hall_ID");
                    table.ForeignKey(
                        name: "FK_Showtimes_Movies_Movie_ID",
                        column: x => x.Movie_ID,
                        principalTable: "Movies",
                        principalColumn: "Film_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Reservation_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reservation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRegistered = table.Column<bool>(type: "bit", nullable: false),
                    Seat_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Showtime_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Reservation_ID);
                    table.ForeignKey(
                        name: "FK_Reservations_Accounts_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "Accounts",
                        principalColumn: "Account_ID");
                    table.ForeignKey(
                        name: "FK_Reservations_Seats_Seat_ID",
                        column: x => x.Seat_ID,
                        principalTable: "Seats",
                        principalColumn: "Seat_ID");
                    table.ForeignKey(
                        name: "FK_Reservations_Showtimes_Showtime_ID",
                        column: x => x.Showtime_ID,
                        principalTable: "Showtimes",
                        principalColumn: "Showtime_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorsInMovies_Movie_ID",
                table: "ActorsInMovies",
                column: "Movie_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesAndMovies_Movie_ID",
                table: "CategoriesAndMovies",
                column: "Movie_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Director_ID",
                table: "Movies",
                column: "Director_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Account_ID",
                table: "Reservations",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Seat_ID",
                table: "Reservations",
                column: "Seat_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Showtime_ID",
                table: "Reservations",
                column: "Showtime_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_Hall_ID",
                table: "Seats",
                column: "Hall_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_Hall_ID",
                table: "Showtimes",
                column: "Hall_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_Movie_ID",
                table: "Showtimes",
                column: "Movie_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorsInMovies");

            migrationBuilder.DropTable(
                name: "CategoriesAndMovies");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Showtimes");

            migrationBuilder.DropTable(
                name: "CinemaHalls");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
