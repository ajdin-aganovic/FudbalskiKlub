using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudbalskiKlub.Services.Migrations
{
    /// <inheritdoc />
    public partial class novamigracija1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bolest",
                columns: table => new
                {
                    BolestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SifraPovrede = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TipPovrede = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TrajanjePovredeDani = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bolest__345EDD63C1FF3573", x => x.BolestId);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Prezime = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    KorisnickoIme = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    LozinkaHash = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LozinkaSalt = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    StrucnaSprema = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "date", nullable: true),
                    PodUgovorom = table.Column<bool>(type: "bit", nullable: true),
                    PodUgovoromOd = table.Column<DateTime>(type: "datetime", nullable: true),
                    PodUgovoromDo = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__80B06D41D28B3EED", x => x.KorisnikId);
                });

            migrationBuilder.CreateTable(
                name: "Pozicija",
                columns: table => new
                {
                    PozicijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivPozicije = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    KategorijaPozicije = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pozicija__C25169AEA95BEC4D", x => x.PozicijaId);
                });

            migrationBuilder.CreateTable(
                name: "Stadion",
                columns: table => new
                {
                    StadionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivStadiona = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    KapacitetStadiona = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Stadion__DDB3F389E8282FAE", x => x.StadionId);
                });

            migrationBuilder.CreateTable(
                name: "Trening",
                columns: table => new
                {
                    TreningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivTreninga = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TipTreninga = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Trening__3B04A8D37D605210", x => x.TreningId);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    UlogaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivUloge = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PodtipUloge = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Uloga__DCAB23CBA0BD3CE4", x => x.UlogaId);
                });

            migrationBuilder.CreateTable(
                name: "Clanarina",
                columns: table => new
                {
                    ClanarinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    IznosClanarine = table.Column<double>(type: "float", nullable: true),
                    Dug = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clanarin__C51E3B9744FDF577", x => x.ClanarinaId);
                    table.ForeignKey(
                        name: "FK_KorisnikClanarina",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                });

            migrationBuilder.CreateTable(
                name: "KorisnikBolest",
                columns: table => new
                {
                    KorisnikBolestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    BolestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__8ECF77DF3087028A", x => x.KorisnikBolestId);
                    table.ForeignKey(
                        name: "FK_BolestKorisnikBolest",
                        column: x => x.BolestId,
                        principalTable: "Bolest",
                        principalColumn: "BolestId");
                    table.ForeignKey(
                        name: "FK_KorisnikKorisnikBolest",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                });

            migrationBuilder.CreateTable(
                name: "Statistika",
                columns: table => new
                {
                    StatistikaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Golovi = table.Column<int>(type: "int", nullable: true),
                    Asistencije = table.Column<int>(type: "int", nullable: true),
                    IgracMjeseca = table.Column<bool>(type: "bit", nullable: true),
                    BezPrimGola = table.Column<int>(type: "int", nullable: true),
                    ZutiKartoni = table.Column<int>(type: "int", nullable: true),
                    CrveniKartoni = table.Column<int>(type: "int", nullable: true),
                    ProsjecnaOcjena = table.Column<double>(type: "float", nullable: true),
                    OcjenaZadUtak = table.Column<double>(type: "float", nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Statisti__B718DBB73CB4E6D2", x => x.StatistikaId);
                    table.ForeignKey(
                        name: "FK_KorisnikStatistika",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                });

            migrationBuilder.CreateTable(
                name: "TransakcijskiRacun",
                columns: table => new
                {
                    TransakcijskiRacunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojRacuna = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    AdresaPrebivalista = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NazivBanke = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transakc__2F0E2ED1FF943D6E", x => x.TransakcijskiRacunId);
                    table.ForeignKey(
                        name: "FK_KorisnikTransakcijskiRacun",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                });

            migrationBuilder.CreateTable(
                name: "KorisnikPozicija",
                columns: table => new
                {
                    KorisnikPozicijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    PozicijaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__F374D25700F98E73", x => x.KorisnikPozicijaId);
                    table.ForeignKey(
                        name: "FK_KorisnikKorisnikPozicija",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                    table.ForeignKey(
                        name: "FK_PozicijaKorisnikPozicija",
                        column: x => x.PozicijaId,
                        principalTable: "Pozicija",
                        principalColumn: "PozicijaId");
                });

            migrationBuilder.CreateTable(
                name: "Termin",
                columns: table => new
                {
                    TerminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SifraTermina = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TipTermina = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    StadionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Termin__42126C95BA3670B3", x => x.TerminId);
                    table.ForeignKey(
                        name: "FK_StadionTermin",
                        column: x => x.StadionId,
                        principalTable: "Stadion",
                        principalColumn: "StadionId");
                });

            migrationBuilder.CreateTable(
                name: "TreningStadion",
                columns: table => new
                {
                    TreningStadionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreningId = table.Column<int>(type: "int", nullable: true),
                    StadionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TreningS__83078871C7602F15", x => x.TreningStadionId);
                    table.ForeignKey(
                        name: "FK_StadionTreningStadion",
                        column: x => x.StadionId,
                        principalTable: "Stadion",
                        principalColumn: "StadionId");
                    table.ForeignKey(
                        name: "FK_TreningTreningStadion",
                        column: x => x.TreningId,
                        principalTable: "Trening",
                        principalColumn: "TreningId");
                });

            migrationBuilder.CreateTable(
                name: "KorisnikUloga",
                columns: table => new
                {
                    KorisnikUlogaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    UlogaId = table.Column<int>(type: "int", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__1608726E78CD53A3", x => x.KorisnikUlogaId);
                    table.ForeignKey(
                        name: "FK_KorisnikKorisnikUloga",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                    table.ForeignKey(
                        name: "FK_UlogaKorisnikUloga",
                        column: x => x.UlogaId,
                        principalTable: "Uloga",
                        principalColumn: "UlogaId");
                });

            migrationBuilder.CreateTable(
                name: "Plata",
                columns: table => new
                {
                    PlataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransakcijskiRacunId = table.Column<int>(type: "int", nullable: true),
                    StateMachine = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Iznos = table.Column<double>(type: "float", nullable: true),
                    DatumSlanja = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Plata__373F7313BACBD819", x => x.PlataId);
                    table.ForeignKey(
                        name: "FK_TransakcijskiRacunPlata",
                        column: x => x.TransakcijskiRacunId,
                        principalTable: "TransakcijskiRacun",
                        principalColumn: "TransakcijskiRacunId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clanarina_KorisnikId",
                table: "Clanarina",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikBolest_BolestId",
                table: "KorisnikBolest",
                column: "BolestId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikBolest_KorisnikId",
                table: "KorisnikBolest",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikPozicija_KorisnikId",
                table: "KorisnikPozicija",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikPozicija_PozicijaId",
                table: "KorisnikPozicija",
                column: "PozicijaId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_KorisnikId",
                table: "KorisnikUloga",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_UlogaId",
                table: "KorisnikUloga",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_Plata_TransakcijskiRacunId",
                table: "Plata",
                column: "TransakcijskiRacunId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistika_KorisnikId",
                table: "Statistika",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_StadionId",
                table: "Termin",
                column: "StadionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransakcijskiRacun_KorisnikId",
                table: "TransakcijskiRacun",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_TreningStadion_StadionId",
                table: "TreningStadion",
                column: "StadionId");

            migrationBuilder.CreateIndex(
                name: "IX_TreningStadion_TreningId",
                table: "TreningStadion",
                column: "TreningId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clanarina");

            migrationBuilder.DropTable(
                name: "KorisnikBolest");

            migrationBuilder.DropTable(
                name: "KorisnikPozicija");

            migrationBuilder.DropTable(
                name: "KorisnikUloga");

            migrationBuilder.DropTable(
                name: "Plata");

            migrationBuilder.DropTable(
                name: "Statistika");

            migrationBuilder.DropTable(
                name: "Termin");

            migrationBuilder.DropTable(
                name: "TreningStadion");

            migrationBuilder.DropTable(
                name: "Bolest");

            migrationBuilder.DropTable(
                name: "Pozicija");

            migrationBuilder.DropTable(
                name: "Uloga");

            migrationBuilder.DropTable(
                name: "TransakcijskiRacun");

            migrationBuilder.DropTable(
                name: "Stadion");

            migrationBuilder.DropTable(
                name: "Trening");

            migrationBuilder.DropTable(
                name: "Korisnik");
        }
    }
}
