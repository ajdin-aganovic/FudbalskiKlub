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
        public bool? Placena { get; set; }
        public DateTime? DatumPlacanja { get; set; }

        public bool? Izbrisan { get; set; }

        //public virtual Korisnik? Korisnik { get; set; }
    }

}

