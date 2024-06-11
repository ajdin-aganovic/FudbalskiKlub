using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudbalskiKlub.Services.Migrations
{
    /// <inheritdoc />
    public partial class DodanaPoljaIzbrisanIStateMachine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Izbrisan",
                table: "Uloga",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Izbrisan",
                table: "Trening",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Izbrisan",
                table: "TransakcijskiRacun",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Izbrisan",
                table: "Termin",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Izbrisan",
                table: "Statistika",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Izbrisan",
                table: "Stadion",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Izbrisan",
                table: "Proizvod",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateMachine",
                table: "Proizvod",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Izbrisan",
                table: "Pozicija",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Izbrisan",
                table: "Plata",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Izbrisan",
                table: "Korisnik",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Izbrisan",
                table: "Clanarina",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Izbrisan",
                table: "Bolest",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Izbrisan",
                table: "Uloga");

            migrationBuilder.DropColumn(
                name: "Izbrisan",
                table: "Trening");

            migrationBuilder.DropColumn(
                name: "Izbrisan",
                table: "TransakcijskiRacun");

            migrationBuilder.DropColumn(
                name: "Izbrisan",
                table: "Termin");

            migrationBuilder.DropColumn(
                name: "Izbrisan",
                table: "Statistika");

            migrationBuilder.DropColumn(
                name: "Izbrisan",
                table: "Stadion");

            migrationBuilder.DropColumn(
                name: "Izbrisan",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "StateMachine",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "Izbrisan",
                table: "Pozicija");

            migrationBuilder.DropColumn(
                name: "Izbrisan",
                table: "Plata");

            migrationBuilder.DropColumn(
                name: "Izbrisan",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "Izbrisan",
                table: "Clanarina");

            migrationBuilder.DropColumn(
                name: "Izbrisan",
                table: "Bolest");
        }
    }
}
