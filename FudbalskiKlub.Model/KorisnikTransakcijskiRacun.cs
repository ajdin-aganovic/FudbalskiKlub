
using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Model
{
    public partial class KorisnikTransakcijskiRacun
    {
        public int KorisnikTransakcijskiRacunId { get; set; }

        public int KorisnikId { get; set; }

        public int TransakcijskiRacunId { get; set; }

        public DateTime? DatumIzmjene { get; set; }

        //public virtual Korisnik Korisnik { get; set; } = null!;

        //public virtual TransakcijskiRacun TransakcijskiRacun { get; set; } = null!;
    }

}

