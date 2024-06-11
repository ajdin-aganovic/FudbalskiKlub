﻿// <auto-generated />
using System;
using FudbalskiKlub.Services.Database1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FudbalskiKlub.Services.Migrations
{
    [DbContext(typeof(MiniafkContext))]
    [Migration("20240611010532_DodanaPoljaIzbrisanIStateMachine")]
    partial class DodanaPoljaIzbrisanIStateMachine
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Bolest", b =>
                {
                    b.Property<int>("BolestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BolestId"));

                    b.Property<bool?>("Izbrisan")
                        .HasColumnType("bit");

                    b.Property<string>("SifraPovrede")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TipPovrede")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("TrajanjePovredeDani")
                        .HasColumnType("int");

                    b.HasKey("BolestId")
                        .HasName("PK__Bolest__345EDD63C1FF3573");

                    b.ToTable("Bolest", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Clanarina", b =>
                {
                    b.Property<int>("ClanarinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClanarinaId"));

                    b.Property<DateTime?>("DatumPlacanja")
                        .HasColumnType("datetime");

                    b.Property<double?>("Dug")
                        .HasColumnType("float");

                    b.Property<bool?>("Izbrisan")
                        .HasColumnType("bit");

                    b.Property<double?>("IznosClanarine")
                        .HasColumnType("float");

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<bool?>("Placena")
                        .HasColumnType("bit");

                    b.HasKey("ClanarinaId")
                        .HasName("PK__Clanarin__C51E3B9744FDF577");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Clanarina", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Korisnik", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorisnikId"));

                    b.Property<DateTime?>("DatumRodjenja")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Ime")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("Izbrisan")
                        .HasColumnType("bit");

                    b.Property<string>("KorisnickoIme")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LozinkaHash")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LozinkaSalt")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("PodUgovorom")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PodUgovoromDo")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("PodUgovoromOd")
                        .HasColumnType("datetime");

                    b.Property<string>("Prezime")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("StrucnaSprema")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Uloga")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("KorisnikId")
                        .HasName("PK__Korisnik__80B06D41D28B3EED");

                    b.ToTable("Korisnik", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.KorisnikBolest", b =>
                {
                    b.Property<int>("KorisnikBolestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorisnikBolestId"));

                    b.Property<int>("BolestId")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.HasKey("KorisnikBolestId")
                        .HasName("PK__Korisnik__8ECF77DF3087028A");

                    b.HasIndex("BolestId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("KorisnikBolest", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.KorisnikPozicija", b =>
                {
                    b.Property<int>("KorisnikPozicijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorisnikPozicijaId"));

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int?>("PozicijaId")
                        .HasColumnType("int");

                    b.HasKey("KorisnikPozicijaId")
                        .HasName("PK__Korisnik__F374D25700F98E73");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("PozicijaId");

                    b.ToTable("KorisnikPozicija", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.KorisnikTransakcijskiRacun", b =>
                {
                    b.Property<int>("KorisnikTransakcijskiRacunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorisnikTransakcijskiRacunId"));

                    b.Property<DateTime?>("DatumIzmjene")
                        .HasColumnType("datetime");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("TransakcijskiRacunId")
                        .HasColumnType("int");

                    b.HasKey("KorisnikTransakcijskiRacunId")
                        .HasName("PK__Korisnik__1608726E51D03733");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("TransakcijskiRacunId");

                    b.ToTable("KorisnikTransakcijskiRacun", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.KorisnikUloga", b =>
                {
                    b.Property<int>("KorisnikUlogaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorisnikUlogaId"));

                    b.Property<DateTime?>("DatumIzmjene")
                        .HasColumnType("datetime");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("UlogaId")
                        .HasColumnType("int");

                    b.HasKey("KorisnikUlogaId")
                        .HasName("PK__Korisnik__1608726E78CD53A3");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("UlogaId");

                    b.ToTable("KorisnikUloga", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Narudzba", b =>
                {
                    b.Property<int>("NarudzbaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NarudzbaId"));

                    b.Property<string>("BrojNarudzba")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("Datum")
                        .HasColumnType("datetime");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("NarudzbaId")
                        .HasName("PK__Narudzba__FBEC1377D43365F9");

                    b.ToTable("Narudzba", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.NarudzbaStavke", b =>
                {
                    b.Property<int>("NarudzbaStavkeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NarudzbaStavkeId"));

                    b.Property<int?>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int?>("NarudzbaId")
                        .HasColumnType("int");

                    b.Property<int?>("ProizvodId")
                        .HasColumnType("int");

                    b.HasKey("NarudzbaStavkeId")
                        .HasName("PK__Narudzba__7DC8EFED3DA2E1FE");

                    b.HasIndex("NarudzbaId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("NarudzbaStavke", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Platum", b =>
                {
                    b.Property<int>("PlataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlataId"));

                    b.Property<DateTime?>("DatumSlanja")
                        .HasColumnType("datetime");

                    b.Property<bool?>("Izbrisan")
                        .HasColumnType("bit");

                    b.Property<double?>("Iznos")
                        .HasColumnType("float");

                    b.Property<string>("StateMachine")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("TransakcijskiRacunId")
                        .HasColumnType("int");

                    b.HasKey("PlataId")
                        .HasName("PK__Plata__373F7313BACBD819");

                    b.HasIndex("TransakcijskiRacunId");

                    b.ToTable("Plata");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Pozicija", b =>
                {
                    b.Property<int>("PozicijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PozicijaId"));

                    b.Property<bool?>("Izbrisan")
                        .HasColumnType("bit");

                    b.Property<string>("KategorijaPozicije")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NazivPozicije")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("PozicijaId")
                        .HasName("PK__Pozicija__C25169AEA95BEC4D");

                    b.ToTable("Pozicija", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Proizvod", b =>
                {
                    b.Property<int>("ProizvodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProizvodId"));

                    b.Property<double?>("Cijena")
                        .HasColumnType("float");

                    b.Property<bool?>("Izbrisan")
                        .HasColumnType("bit");

                    b.Property<string>("Kategorija")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Kolicina")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Sifra")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("StateMachine")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProizvodId")
                        .HasName("PK__Proizvod__21A8BFF81155EE96");

                    b.ToTable("Proizvod", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Stadion", b =>
                {
                    b.Property<int>("StadionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StadionId"));

                    b.Property<bool?>("Izbrisan")
                        .HasColumnType("bit");

                    b.Property<int?>("KapacitetStadiona")
                        .HasColumnType("int");

                    b.Property<string>("NazivStadiona")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("StadionId")
                        .HasName("PK__Stadion__DDB3F389E8282FAE");

                    b.ToTable("Stadion", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Statistika", b =>
                {
                    b.Property<int>("StatistikaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatistikaId"));

                    b.Property<int?>("Asistencije")
                        .HasColumnType("int");

                    b.Property<int?>("BezPrimGola")
                        .HasColumnType("int");

                    b.Property<int?>("CrveniKartoni")
                        .HasColumnType("int");

                    b.Property<int?>("Golovi")
                        .HasColumnType("int");

                    b.Property<bool?>("IgracMjeseca")
                        .HasColumnType("bit");

                    b.Property<bool?>("Izbrisan")
                        .HasColumnType("bit");

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<double?>("OcjenaZadUtak")
                        .HasColumnType("float");

                    b.Property<double?>("ProsjecnaOcjena")
                        .HasColumnType("float");

                    b.Property<int?>("ZutiKartoni")
                        .HasColumnType("int");

                    b.HasKey("StatistikaId")
                        .HasName("PK__Statisti__B718DBB73CB4E6D2");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Statistika", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Termin", b =>
                {
                    b.Property<int>("TerminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TerminId"));

                    b.Property<bool?>("Izbrisan")
                        .HasColumnType("bit");

                    b.Property<string>("Rezultat")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SifraTermina")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("StadionId")
                        .HasColumnType("int");

                    b.Property<string>("TipTermina")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TerminId")
                        .HasName("PK__Termin__42126C95BA3670B3");

                    b.HasIndex("StadionId");

                    b.ToTable("Termin", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.TransakcijskiRacun", b =>
                {
                    b.Property<int>("TransakcijskiRacunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransakcijskiRacunId"));

                    b.Property<string>("AdresaPrebivalista")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("BrojRacuna")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<bool?>("Izbrisan")
                        .HasColumnType("bit");

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("NazivBanke")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TransakcijskiRacunId")
                        .HasName("PK__Transakc__2F0E2ED1FF943D6E");

                    b.HasIndex("KorisnikId");

                    b.ToTable("TransakcijskiRacun", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Trening", b =>
                {
                    b.Property<int>("TreningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TreningId"));

                    b.Property<DateTime?>("DatumTreninga")
                        .HasColumnType("datetime");

                    b.Property<bool?>("Izbrisan")
                        .HasColumnType("bit");

                    b.Property<string>("NazivTreninga")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TipTreninga")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TreningId")
                        .HasName("PK__Trening__3B04A8D37D605210");

                    b.ToTable("Trening", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.TreningStadion", b =>
                {
                    b.Property<int>("TreningStadionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TreningStadionId"));

                    b.Property<int?>("StadionId")
                        .HasColumnType("int");

                    b.Property<int?>("TreningId")
                        .HasColumnType("int");

                    b.HasKey("TreningStadionId")
                        .HasName("PK__TreningS__83078871C7602F15");

                    b.HasIndex("StadionId");

                    b.HasIndex("TreningId");

                    b.ToTable("TreningStadion", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Uloga", b =>
                {
                    b.Property<int>("UlogaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UlogaId"));

                    b.Property<bool?>("Izbrisan")
                        .HasColumnType("bit");

                    b.Property<string>("NazivUloge")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PodtipUloge")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("UlogaId")
                        .HasName("PK__Uloga__DCAB23CBA0BD3CE4");

                    b.ToTable("Uloga", (string)null);
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Clanarina", b =>
                {
                    b.HasOne("FudbalskiKlub.Services.Database1.Korisnik", "Korisnik")
                        .WithMany("Clanarinas")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK_KorisnikClanarina");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.KorisnikBolest", b =>
                {
                    b.HasOne("FudbalskiKlub.Services.Database1.Bolest", "Bolest")
                        .WithMany("KorisnikBolests")
                        .HasForeignKey("BolestId")
                        .IsRequired()
                        .HasConstraintName("FK_BolestKorisnikBolest");

                    b.HasOne("FudbalskiKlub.Services.Database1.Korisnik", "Korisnik")
                        .WithMany("KorisnikBolests")
                        .HasForeignKey("KorisnikId")
                        .IsRequired()
                        .HasConstraintName("FK_KorisnikKorisnikBolest");

                    b.Navigation("Bolest");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.KorisnikPozicija", b =>
                {
                    b.HasOne("FudbalskiKlub.Services.Database1.Korisnik", "Korisnik")
                        .WithMany("KorisnikPozicijas")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK_KorisnikKorisnikPozicija");

                    b.HasOne("FudbalskiKlub.Services.Database1.Pozicija", "Pozicija")
                        .WithMany("KorisnikPozicijas")
                        .HasForeignKey("PozicijaId")
                        .HasConstraintName("FK_PozicijaKorisnikPozicija");

                    b.Navigation("Korisnik");

                    b.Navigation("Pozicija");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.KorisnikTransakcijskiRacun", b =>
                {
                    b.HasOne("FudbalskiKlub.Services.Database1.Korisnik", "Korisnik")
                        .WithMany("KorisnikTransakcijskiRacuns")
                        .HasForeignKey("KorisnikId")
                        .IsRequired()
                        .HasConstraintName("FK_KorisnikKorisnikTransakcijskiRacun");

                    b.HasOne("FudbalskiKlub.Services.Database1.TransakcijskiRacun", "TransakcijskiRacun")
                        .WithMany("KorisnikTransakcijskiRacuns")
                        .HasForeignKey("TransakcijskiRacunId")
                        .IsRequired()
                        .HasConstraintName("FK_TransakcijskiRacunKorisnikTransakcijskiRacun");

                    b.Navigation("Korisnik");

                    b.Navigation("TransakcijskiRacun");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.KorisnikUloga", b =>
                {
                    b.HasOne("FudbalskiKlub.Services.Database1.Korisnik", "Korisnik")
                        .WithMany("KorisnikUlogas")
                        .HasForeignKey("KorisnikId")
                        .IsRequired()
                        .HasConstraintName("FK_KorisnikKorisnikUloga");

                    b.HasOne("FudbalskiKlub.Services.Database1.Uloga", "Uloga")
                        .WithMany("KorisnikUlogas")
                        .HasForeignKey("UlogaId")
                        .IsRequired()
                        .HasConstraintName("FK_UlogaKorisnikUloga");

                    b.Navigation("Korisnik");

                    b.Navigation("Uloga");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.NarudzbaStavke", b =>
                {
                    b.HasOne("FudbalskiKlub.Services.Database1.Narudzba", "Narudzba")
                        .WithMany("NarudzbaStavkes")
                        .HasForeignKey("NarudzbaId")
                        .HasConstraintName("FK_NarudzbaStavkeNarudzba");

                    b.HasOne("FudbalskiKlub.Services.Database1.Proizvod", "Proizvod")
                        .WithMany("NarudzbaStavkes")
                        .HasForeignKey("ProizvodId")
                        .HasConstraintName("FK_NarudzbaStavkeProizvod");

                    b.Navigation("Narudzba");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Platum", b =>
                {
                    b.HasOne("FudbalskiKlub.Services.Database1.TransakcijskiRacun", "TransakcijskiRacun")
                        .WithMany("Plata")
                        .HasForeignKey("TransakcijskiRacunId")
                        .HasConstraintName("FK_TransakcijskiRacunPlata");

                    b.Navigation("TransakcijskiRacun");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Statistika", b =>
                {
                    b.HasOne("FudbalskiKlub.Services.Database1.Korisnik", "Korisnik")
                        .WithMany("Statistikas")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK_KorisnikStatistika");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Termin", b =>
                {
                    b.HasOne("FudbalskiKlub.Services.Database1.Stadion", "Stadion")
                        .WithMany("Termins")
                        .HasForeignKey("StadionId")
                        .HasConstraintName("FK_StadionTermin");

                    b.Navigation("Stadion");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.TransakcijskiRacun", b =>
                {
                    b.HasOne("FudbalskiKlub.Services.Database1.Korisnik", "Korisnik")
                        .WithMany("TransakcijskiRacuns")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK_KorisnikTransakcijski");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.TreningStadion", b =>
                {
                    b.HasOne("FudbalskiKlub.Services.Database1.Stadion", "Stadion")
                        .WithMany("TreningStadions")
                        .HasForeignKey("StadionId")
                        .HasConstraintName("FK_StadionTreningStadion");

                    b.HasOne("FudbalskiKlub.Services.Database1.Trening", "Trening")
                        .WithMany("TreningStadions")
                        .HasForeignKey("TreningId")
                        .HasConstraintName("FK_TreningTreningStadion");

                    b.Navigation("Stadion");

                    b.Navigation("Trening");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Bolest", b =>
                {
                    b.Navigation("KorisnikBolests");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Korisnik", b =>
                {
                    b.Navigation("Clanarinas");

                    b.Navigation("KorisnikBolests");

                    b.Navigation("KorisnikPozicijas");

                    b.Navigation("KorisnikTransakcijskiRacuns");

                    b.Navigation("KorisnikUlogas");

                    b.Navigation("Statistikas");

                    b.Navigation("TransakcijskiRacuns");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Narudzba", b =>
                {
                    b.Navigation("NarudzbaStavkes");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Pozicija", b =>
                {
                    b.Navigation("KorisnikPozicijas");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Proizvod", b =>
                {
                    b.Navigation("NarudzbaStavkes");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Stadion", b =>
                {
                    b.Navigation("Termins");

                    b.Navigation("TreningStadions");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.TransakcijskiRacun", b =>
                {
                    b.Navigation("KorisnikTransakcijskiRacuns");

                    b.Navigation("Plata");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Trening", b =>
                {
                    b.Navigation("TreningStadions");
                });

            modelBuilder.Entity("FudbalskiKlub.Services.Database1.Uloga", b =>
                {
                    b.Navigation("KorisnikUlogas");
                });
#pragma warning restore 612, 618
        }
    }
}
