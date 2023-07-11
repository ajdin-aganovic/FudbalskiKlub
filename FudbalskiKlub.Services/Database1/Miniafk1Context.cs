using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FudbalskiKlub.Services.Database1;

public partial class Miniafk1Context : DbContext
{
    public Miniafk1Context()
    {
    }

    public Miniafk1Context(DbContextOptions<Miniafk1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Bolest> Bolests { get; set; }

    public virtual DbSet<Clanarina> Clanarinas { get; set; }

    public virtual DbSet<Korisnik> Korisniks { get; set; }

    public virtual DbSet<KorisnikBolest> KorisnikBolests { get; set; }

    public virtual DbSet<KorisnikPozicija> KorisnikPozicijas { get; set; }

    public virtual DbSet<KorisnikTransakcijskiRacun> KorisnikTransakcijskiRacuns { get; set; }

    public virtual DbSet<KorisnikUloga> KorisnikUlogas { get; set; }

    public virtual DbSet<Platum> Plata { get; set; }

    public virtual DbSet<Pozicija> Pozicijas { get; set; }

    public virtual DbSet<Stadion> Stadions { get; set; }

    public virtual DbSet<Statistika> Statistikas { get; set; }

    public virtual DbSet<Termin> Termins { get; set; }

    public virtual DbSet<TransakcijskiRacun> TransakcijskiRacuns { get; set; }

    public virtual DbSet<Trening> Trenings { get; set; }

    public virtual DbSet<TreningStadion> TreningStadions { get; set; }

    public virtual DbSet<Uloga> Ulogas { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=miniafk1; user=sa1; Password=ASDqwe123!; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bolest>(entity =>
        {
            entity.HasKey(e => e.BolestId).HasName("PK__Bolest__345EDD63C1FF3573");

            entity.ToTable("Bolest");

            entity.Property(e => e.SifraPovrede)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipPovrede)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Clanarina>(entity =>
        {
            entity.HasKey(e => e.ClanarinaId).HasName("PK__Clanarin__C51E3B9744FDF577");

            entity.ToTable("Clanarina");

            entity.HasIndex(e => e.KorisnikId, "IX_Clanarina_KorisnikId");

            entity.Property(e => e.DatumUplate).HasColumnType("datetime");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Clanarinas)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK_KorisnikClanarina");
        });

        modelBuilder.Entity<Korisnik>(entity =>
        {
            entity.HasKey(e => e.KorisnikId).HasName("PK__Korisnik__80B06D41D28B3EED");

            entity.ToTable("Korisnik");

            entity.Property(e => e.DatumRodjenja).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KorisnickoIme)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LozinkaHash)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LozinkaSalt)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PodUgovoromDo).HasColumnType("datetime");
            entity.Property(e => e.PodUgovoromOd).HasColumnType("datetime");
            entity.Property(e => e.Prezime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StrucnaSprema)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<KorisnikBolest>(entity =>
        {
            entity.HasKey(e => e.KorisnikBolestId).HasName("PK__Korisnik__8ECF77DF3087028A");

            entity.ToTable("KorisnikBolest");

            entity.HasIndex(e => e.BolestId, "IX_KorisnikBolest_BolestId");

            entity.HasIndex(e => e.KorisnikId, "IX_KorisnikBolest_KorisnikId");

            entity.HasOne(d => d.Bolest).WithMany(p => p.KorisnikBolests)
                .HasForeignKey(d => d.BolestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BolestKorisnikBolest");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KorisnikBolests)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KorisnikKorisnikBolest");
        });

        modelBuilder.Entity<KorisnikPozicija>(entity =>
        {
            entity.HasKey(e => e.KorisnikPozicijaId).HasName("PK__Korisnik__F374D25700F98E73");

            entity.ToTable("KorisnikPozicija");

            entity.HasIndex(e => e.KorisnikId, "IX_KorisnikPozicija_KorisnikId");

            entity.HasIndex(e => e.PozicijaId, "IX_KorisnikPozicija_PozicijaId");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KorisnikPozicijas)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK_KorisnikKorisnikPozicija");

            entity.HasOne(d => d.Pozicija).WithMany(p => p.KorisnikPozicijas)
                .HasForeignKey(d => d.PozicijaId)
                .HasConstraintName("FK_PozicijaKorisnikPozicija");
        });

        modelBuilder.Entity<KorisnikTransakcijskiRacun>(entity =>
        {
            entity.HasKey(e => e.KorisnikTransakcijskiRacunId).HasName("PK__Korisnik__1608726E51D03733");

            entity.ToTable("KorisnikTransakcijskiRacun");

            entity.HasIndex(e => e.KorisnikId, "IX_KorisnikTransakcijskiRacun_KorisnikId");

            entity.HasIndex(e => e.TransakcijskiRacunId, "IX_KorisnikTransakcijskiRacun_TransakcijskiRacunId");

            entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KorisnikTransakcijskiRacuns)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KorisnikKorisnikTransakcijskiRacun");

            entity.HasOne(d => d.TransakcijskiRacun).WithMany(p => p.KorisnikTransakcijskiRacuns)
                .HasForeignKey(d => d.TransakcijskiRacunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransakcijskiRacunKorisnikTransakcijskiRacun");
        });

        modelBuilder.Entity<KorisnikUloga>(entity =>
        {
            entity.HasKey(e => e.KorisnikUlogaId).HasName("PK__Korisnik__1608726E78CD53A3");

            entity.ToTable("KorisnikUloga");

            entity.HasIndex(e => e.KorisnikId, "IX_KorisnikUloga_KorisnikId");

            entity.HasIndex(e => e.UlogaId, "IX_KorisnikUloga_UlogaId");

            entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KorisnikUlogas)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KorisnikKorisnikUloga");

            entity.HasOne(d => d.Uloga).WithMany(p => p.KorisnikUlogas)
                .HasForeignKey(d => d.UlogaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UlogaKorisnikUloga");
        });

        modelBuilder.Entity<Platum>(entity =>
        {
            entity.HasKey(e => e.PlataId).HasName("PK__Plata__373F7313BACBD819");

            entity.HasIndex(e => e.TransakcijskiRacunId, "IX_Plata_TransakcijskiRacunId");

            entity.Property(e => e.DatumSlanja).HasColumnType("datetime");
            entity.Property(e => e.StateMachine)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.TransakcijskiRacun).WithMany(p => p.Plata)
                .HasForeignKey(d => d.TransakcijskiRacunId)
                .HasConstraintName("FK_TransakcijskiRacunPlata");
        });

        modelBuilder.Entity<Pozicija>(entity =>
        {
            entity.HasKey(e => e.PozicijaId).HasName("PK__Pozicija__C25169AEA95BEC4D");

            entity.ToTable("Pozicija");

            entity.Property(e => e.KategorijaPozicije)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NazivPozicije)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stadion>(entity =>
        {
            entity.HasKey(e => e.StadionId).HasName("PK__Stadion__DDB3F389E8282FAE");

            entity.ToTable("Stadion");

            entity.Property(e => e.NazivStadiona)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Statistika>(entity =>
        {
            entity.HasKey(e => e.StatistikaId).HasName("PK__Statisti__B718DBB73CB4E6D2");

            entity.ToTable("Statistika");

            entity.HasIndex(e => e.KorisnikId, "IX_Statistika_KorisnikId");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Statistikas)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK_KorisnikStatistika");
        });

        modelBuilder.Entity<Termin>(entity =>
        {
            entity.HasKey(e => e.TerminId).HasName("PK__Termin__42126C95BA3670B3");

            entity.ToTable("Termin");

            entity.HasIndex(e => e.StadionId, "IX_Termin_StadionId");

            entity.Property(e => e.DatumTermina).HasColumnType("datetime");
            entity.Property(e => e.SifraTermina)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipTermina)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Stadion).WithMany(p => p.Termins)
                .HasForeignKey(d => d.StadionId)
                .HasConstraintName("FK_StadionTermin");
        });

        modelBuilder.Entity<TransakcijskiRacun>(entity =>
        {
            entity.HasKey(e => e.TransakcijskiRacunId).HasName("PK__Transakc__2F0E2ED1FF943D6E");

            entity.ToTable("TransakcijskiRacun");

            entity.Property(e => e.AdresaPrebivalista)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BrojRacuna)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NazivBanke)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Trening>(entity =>
        {
            entity.HasKey(e => e.TreningId).HasName("PK__Trening__3B04A8D37D605210");

            entity.ToTable("Trening");

            entity.Property(e => e.DatumTreninga).HasColumnType("datetime");
            entity.Property(e => e.NazivTreninga)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipTreninga)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TreningStadion>(entity =>
        {
            entity.HasKey(e => e.TreningStadionId).HasName("PK__TreningS__83078871C7602F15");

            entity.ToTable("TreningStadion");

            entity.HasIndex(e => e.StadionId, "IX_TreningStadion_StadionId");

            entity.HasIndex(e => e.TreningId, "IX_TreningStadion_TreningId");

            entity.HasOne(d => d.Stadion).WithMany(p => p.TreningStadions)
                .HasForeignKey(d => d.StadionId)
                .HasConstraintName("FK_StadionTreningStadion");

            entity.HasOne(d => d.Trening).WithMany(p => p.TreningStadions)
                .HasForeignKey(d => d.TreningId)
                .HasConstraintName("FK_TreningTreningStadion");
        });

        modelBuilder.Entity<Uloga>(entity =>
        {
            entity.HasKey(e => e.UlogaId).HasName("PK__Uloga__DCAB23CBA0BD3CE4");

            entity.ToTable("Uloga");

            entity.Property(e => e.NazivUloge)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PodtipUloge)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
