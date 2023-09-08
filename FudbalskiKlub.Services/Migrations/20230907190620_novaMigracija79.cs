using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudbalskiKlub.Services.Migrations
{
    /// <inheritdoc />
    public partial class novaMigracija79 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rezultat",
                table: "Termin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumPlacanja",
                table: "Clanarina",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Placena",
                table: "Clanarina",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Narudzbas",
                columns: table => new
                {
                    NarudzbaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojNarudzba = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzbas", x => x.NarudzbaId);
                });

            migrationBuilder.CreateTable(
                name: "Proizvods",
                columns: table => new
                {
                    ProizvodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kategorija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<double>(type: "float", nullable: true),
                    Kolicina = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvods", x => x.ProizvodId);
                });

            migrationBuilder.CreateTable(
                name: "NarudzbaStavkes",
                columns: table => new
                {
                    NarudzbaStavkeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NarudzbaId = table.Column<int>(type: "int", nullable: true),
                    ProizvodId = table.Column<int>(type: "int", nullable: true),
                    Kolicina = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaStavkes", x => x.NarudzbaStavkeId);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavkes_Narudzbas_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzbas",
                        principalColumn: "NarudzbaId");
                    table.ForeignKey(
                        name: "FK_NarudzbaStavkes_Proizvods_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvods",
                        principalColumn: "ProizvodId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavkes_NarudzbaId",
                table: "NarudzbaStavkes",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavkes_ProizvodId",
                table: "NarudzbaStavkes",
                column: "ProizvodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NarudzbaStavkes");

            migrationBuilder.DropTable(
                name: "Narudzbas");

            migrationBuilder.DropTable(
                name: "Proizvods");

            migrationBuilder.DropColumn(
                name: "Rezultat",
                table: "Termin");

            migrationBuilder.DropColumn(
                name: "DatumPlacanja",
                table: "Clanarina");

            migrationBuilder.DropColumn(
                name: "Placena",
                table: "Clanarina");
        }
    }
}
