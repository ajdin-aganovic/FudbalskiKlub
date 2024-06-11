using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Model
{
    public partial class TransakcijskiRacun
    {
        public int TransakcijskiRacunId { get; set; }

        public string? BrojRacuna { get; set; }

        public string? AdresaPrebivalista { get; set; }

        public string? NazivBanke { get; set; }
        public int? KorisnikId { get; set; }
        public bool? Izbrisan { get; set; }


        public virtual ICollection<KorisnikTransakcijskiRacun> KorisnikTransakcijskiRacuns { get; set; } = new List<KorisnikTransakcijskiRacun>();

        public virtual ICollection<Platum> Plata { get; set; } = new List<Platum>();
    }

}

