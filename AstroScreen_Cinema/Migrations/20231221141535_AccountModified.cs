using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstroScreen_Cinema.Migrations
{
    /// <inheritdoc />
    public partial class AccountModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "Accounts");
        }
    }
}
