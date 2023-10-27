using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstroScreen_Cinema.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Account_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Actor_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Categorie_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Categorie_ID);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Director_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Director_ID);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Film_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Director_ID = table.Column<int>(type: "int", nullable: false),
                    Showtime_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Film_ID);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_Director_ID",
                        column: x => x.Director_ID,
                        principalTable: "Directors",
                        principalColumn: "Director_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "actorsInMovies",
                columns: table => new
                {
                    Actor_ID = table.Column<int>(type: "int", nullable: false),
                    Movie_ID = table.Column<int>(type: "int", nullable: false),
                    ActorsFilms_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actorsInMovies", x => new { x.Actor_ID, x.Movie_ID });
                    table.ForeignKey(
                        name: "FK_actorsInMovies_Actors_Actor_ID",
                        column: x => x.Actor_ID,
                        principalTable: "Actors",
                        principalColumn: "Actor_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_actorsInMovies_Movies_Movie_ID",
                        column: x => x.Movie_ID,
                        principalTable: "Movies",
                        principalColumn: "Film_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesAndMovies",
                columns: table => new
                {
                    Category_ID = table.Column<int>(type: "int", nullable: false),
                    Movie_ID = table.Column<int>(type: "int", nullable: false),
                    CategoriesAndFilms_ID = table.Column<int>(type: "int", nullable: false)
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
                name: "CinemaHalls",
                columns: table => new
                {
                    Hall_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumOfSeats = table.Column<int>(type: "int", nullable: false),
                    RowNum = table.Column<int>(type: "int", nullable: false),
                    SeatNum = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Movie_ID = table.Column<int>(type: "int", nullable: false),
                    MovieFilm_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHalls", x => x.Hall_ID);
                    table.ForeignKey(
                        name: "FK_CinemaHalls_Movies_MovieFilm_ID",
                        column: x => x.MovieFilm_ID,
                        principalTable: "Movies",
                        principalColumn: "Film_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Showtimes",
                columns: table => new
                {
                    Showtime_ID = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hall_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showtimes", x => x.Showtime_ID);
                    table.ForeignKey(
                        name: "FK_Showtimes_CinemaHalls_Showtime_ID",
                        column: x => x.Showtime_ID,
                        principalTable: "CinemaHalls",
                        principalColumn: "Hall_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Showtimes_Movies_Showtime_ID",
                        column: x => x.Showtime_ID,
                        principalTable: "Movies",
                        principalColumn: "Film_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Reservation_ID = table.Column<int>(type: "int", nullable: false),
                    Reservation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Seat_ID = table.Column<int>(type: "int", nullable: false),
                    Showtime_ID = table.Column<int>(type: "int", nullable: false),
                    Account_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Reservation_ID);
                    table.ForeignKey(
                        name: "FK_Reservations_Accounts_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "Accounts",
                        principalColumn: "Account_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Showtimes_Reservation_ID",
                        column: x => x.Reservation_ID,
                        principalTable: "Showtimes",
                        principalColumn: "Showtime_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reservation_ID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Seat_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowNum = table.Column<int>(type: "int", nullable: false),
                    SeatNum = table.Column<int>(type: "int", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false),
                    Hall_ID = table.Column<int>(type: "int", nullable: false),
                    Reservation_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Seat_ID);
                    table.ForeignKey(
                        name: "FK_Seats_CinemaHalls_Hall_ID",
                        column: x => x.Hall_ID,
                        principalTable: "CinemaHalls",
                        principalColumn: "Hall_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seats_Reservations_Reservation_ID",
                        column: x => x.Reservation_ID,
                        principalTable: "Reservations",
                        principalColumn: "Reservation_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_actorsInMovies_Movie_ID",
                table: "actorsInMovies",
                column: "Movie_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesAndMovies_Movie_ID",
                table: "CategoriesAndMovies",
                column: "Movie_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHalls_MovieFilm_ID",
                table: "CinemaHalls",
                column: "MovieFilm_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Director_ID",
                table: "Movies",
                column: "Director_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Account_ID",
                table: "Reservations",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_Hall_ID",
                table: "Seats",
                column: "Hall_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_Reservation_ID",
                table: "Seats",
                column: "Reservation_ID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actorsInMovies");

            migrationBuilder.DropTable(
                name: "CategoriesAndMovies");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Accounts");

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
