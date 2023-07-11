using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Model
{
    public partial class Clanarina
    {
        public int ClanarinaId { get; set; }

        public int? KorisnikId { get; set; }

        public double? IznosClanarine { get; set; }

        public double? Dug { get; set; }
        public DateTime? DatumUplate { get; set; }


        //public virtual Korisnik? Korisnik { get; set; }
    }

}

