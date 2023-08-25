using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudbalskiKlub.Services.Migrations
{
    /// <inheritdoc />
    public partial class dodanaKolonaUKorisniku : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikTransakcijskiRacun",
                table: "TransakcijskiRacun");

            migrationBuilder.DropIndex(
                name: "IX_TransakcijskiRacun_KorisnikId",
                table: "TransakcijskiRacun");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "TransakcijskiRacun");

            migrationBuilder.CreateTable(
                name: "KorisnikTransakcijskiRacun",
                columns: table => new
                {
                    KorisnikTransakcijskiRacunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    TransakcijskiRacunId = table.Column<int>(type: "int", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__1608726E51D03733", x => x.KorisnikTransakcijskiRacunId);
                    table.ForeignKey(
                        name: "FK_KorisnikKorisnikTransakcijskiRacun",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                    table.ForeignKey(
                        name: "FK_TransakcijskiRacunKorisnikTransakcijskiRacun",
                        column: x => x.TransakcijskiRacunId,
                        principalTable: "TransakcijskiRacun",
                        principalColumn: "TransakcijskiRacunId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikTransakcijskiRacun_KorisnikId",
                table: "KorisnikTransakcijskiRacun",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikTransakcijskiRacun_TransakcijskiRacunId",
                table: "KorisnikTransakcijskiRacun",
                column: "TransakcijskiRacunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisnikTransakcijskiRacun");

            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "TransakcijskiRacun",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransakcijskiRacun_KorisnikId",
                table: "TransakcijskiRacun",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikTransakcijskiRacun",
                table: "TransakcijskiRacun",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "KorisnikId");
        }
    }
}
