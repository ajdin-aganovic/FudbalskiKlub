using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudbalskiKlub.Services.Migrations
{
    /// <inheritdoc />
    public partial class transakkorisnik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "TransakcijskiRacun",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uloga",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "TransakcijskiRacun");

            migrationBuilder.DropColumn(
                name: "Uloga",
                table: "Korisnik");
        }
    }
}
