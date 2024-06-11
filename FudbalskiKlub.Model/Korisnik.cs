using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Model
{
    public partial class Korisnik
    {
        public int KorisnikId { get; set; }

        public string? Ime { get; set; }

        public string? Prezime { get; set; }

        public string? KorisnickoIme { get; set; }

        public string? Email { get; set; }

        //public string? LozinkaHash { get; set; }

        //public string? LozinkaSalt { get; set; }

        public string? StrucnaSprema { get; set; }

        public DateTime? DatumRodjenja { get; set; }

        public bool? PodUgovorom { get; set; }

        public DateTime? PodUgovoromOd { get; set; }

        public DateTime? PodUgovoromDo { get; set; }
        public string? Uloga { get; set; }

        public bool? Izbrisan { get; set; }

        public virtual ICollection<KorisnikTransakcijskiRacun> KorisnikTransakcijskiRacuns { get; set; } = new List<KorisnikTransakcijskiRacun>();

        public virtual ICollection<KorisnikUloga> KorisnikUlogas { get; set; } = new List<KorisnikUloga>();
        public virtual ICollection<KorisnikBolest> KorisnikBolests { get; set; } = new List<KorisnikBolest>();

        public virtual ICollection<KorisnikPozicija> KorisnikPozicijas { get; set; } = new List<KorisnikPozicija>();
        public virtual ICollection<Clanarina> Clanarinas { get; set; } = new List<Clanarina>();

    }

}

