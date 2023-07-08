using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Model
{
    public partial class KorisnikBolest
    {
        public int KorisnikBolestId { get; set; }

        public int KorisnikId { get; set; }

        public int BolestId { get; set; }

        //public virtual Bolest Bolest { get; set; } = null!;

        //public virtual Korisnik Korisnik { get; set; } = null!;
    }
}
