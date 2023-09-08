using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudbalskiKlub.Services.Migrations
{
    /// <inheritdoc />
    public partial class samoProvjera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaStavkes_Narudzbas_NarudzbaId",
                table: "NarudzbaStavkes");

            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaStavkes_Proizvods_ProizvodId",
                table: "NarudzbaStavkes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proizvods",
                table: "Proizvods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NarudzbaStavkes",
                table: "NarudzbaStavkes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Narudzbas",
                table: "Narudzbas");

            migrationBuilder.RenameTable(
                name: "Proizvods",
                newName: "Proizvod");

            migrationBuilder.RenameTable(
                name: "NarudzbaStavkes",
                newName: "NarudzbaStavke");

            migrationBuilder.RenameTable(
                name: "Narudzbas",
                newName: "Narudzba");

            migrationBuilder.RenameIndex(
                name: "IX_NarudzbaStavkes_ProizvodId",
                table: "NarudzbaStavke",
                newName: "IX_NarudzbaStavke_ProizvodId");

            migrationBuilder.RenameIndex(
                name: "IX_NarudzbaStavkes_NarudzbaId",
                table: "NarudzbaStavke",
                newName: "IX_NarudzbaStavke_NarudzbaId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumTreninga",
                table: "Trening",
                type: "datetime",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rezultat",
                table: "Termin",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Uloga",
                table: "Korisnik",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumPlacanja",
                table: "Clanarina",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sifra",
                table: "Proizvod",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Proizvod",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Kategorija",
                table: "Proizvod",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Narudzba",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datum",
                table: "Narudzba",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrojNarudzba",
                table: "Narudzba",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Proizvod__21A8BFF81155EE96",
                table: "Proizvod",
                column: "ProizvodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Narudzba__7DC8EFED3DA2E1FE",
                table: "NarudzbaStavke",
                column: "NarudzbaStavkeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Narudzba__FBEC1377D43365F9",
                table: "Narudzba",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_TransakcijskiRacun_KorisnikId",
                table: "TransakcijskiRacun",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaStavkeNarudzba",
                table: "NarudzbaStavke",
                column: "NarudzbaId",
                principalTable: "Narudzba",
                principalColumn: "NarudzbaId");

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaStavkeProizvod",
                table: "NarudzbaStavke",
                column: "ProizvodId",
                principalTable: "Proizvod",
                principalColumn: "ProizvodId");

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikTransakcijski",
                table: "TransakcijskiRacun",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "KorisnikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaStavkeNarudzba",
                table: "NarudzbaStavke");

            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaStavkeProizvod",
                table: "NarudzbaStavke");

            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikTransakcijski",
                table: "TransakcijskiRacun");

            migrationBuilder.DropIndex(
                name: "IX_TransakcijskiRacun_KorisnikId",
                table: "TransakcijskiRacun");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Proizvod__21A8BFF81155EE96",
                table: "Proizvod");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Narudzba__7DC8EFED3DA2E1FE",
                table: "NarudzbaStavke");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Narudzba__FBEC1377D43365F9",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "DatumTreninga",
                table: "Trening");

            migrationBuilder.RenameTable(
                name: "Proizvod",
                newName: "Proizvods");

            migrationBuilder.RenameTable(
                name: "NarudzbaStavke",
                newName: "NarudzbaStavkes");

            migrationBuilder.RenameTable(
                name: "Narudzba",
                newName: "Narudzbas");

            migrationBuilder.RenameIndex(
                name: "IX_NarudzbaStavke_ProizvodId",
                table: "NarudzbaStavkes",
                newName: "IX_NarudzbaStavkes_ProizvodId");

            migrationBuilder.RenameIndex(
                name: "IX_NarudzbaStavke_NarudzbaId",
                table: "NarudzbaStavkes",
                newName: "IX_NarudzbaStavkes_NarudzbaId");

            migrationBuilder.AlterColumn<string>(
                name: "Rezultat",
                table: "Termin",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Uloga",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumPlacanja",
                table: "Clanarina",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sifra",
                table: "Proizvods",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Proizvods",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Kategorija",
                table: "Proizvods",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Narudzbas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datum",
                table: "Narudzbas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrojNarudzba",
                table: "Narudzbas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proizvods",
                table: "Proizvods",
                column: "ProizvodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NarudzbaStavkes",
                table: "NarudzbaStavkes",
                column: "NarudzbaStavkeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Narudzbas",
                table: "Narudzbas",
                column: "NarudzbaId");

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaStavkes_Narudzbas_NarudzbaId",
                table: "NarudzbaStavkes",
                column: "NarudzbaId",
                principalTable: "Narudzbas",
                principalColumn: "NarudzbaId");

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaStavkes_Proizvods_ProizvodId",
                table: "NarudzbaStavkes",
                column: "ProizvodId",
                principalTable: "Proizvods",
                principalColumn: "ProizvodId");
        }
    }
}
