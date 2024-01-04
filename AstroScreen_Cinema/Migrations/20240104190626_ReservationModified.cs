using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstroScreen_Cinema.Migrations
{
    /// <inheritdoc />
    public partial class ReservationModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Seats_Seat_ID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_Seat_ID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Seat_ID",
                table: "Reservations");

            migrationBuilder.AddColumn<Guid>(
                name: "Reservation_ID",
                table: "Seats",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Seats_Reservation_ID",
                table: "Seats",
                column: "Reservation_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Reservations_Reservation_ID",
                table: "Seats",
                column: "Reservation_ID",
                principalTable: "Reservations",
                principalColumn: "Reservation_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Reservations_Reservation_ID",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_Reservation_ID",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "Reservation_ID",
                table: "Seats");

            migrationBuilder.AddColumn<Guid>(
                name: "Seat_ID",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Seat_ID",
                table: "Reservations",
                column: "Seat_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Seats_Seat_ID",
                table: "Reservations",
                column: "Seat_ID",
                principalTable: "Seats",
                principalColumn: "Seat_ID");
        }
    }
}
