using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Model
{
    public partial class Statistika
    {
        public int StatistikaId { get; set; }
        public int? KorisnikId { get; set; }

        public int? Golovi { get; set; }

        public int? Asistencije { get; set; }

        public bool? IgracMjeseca { get; set; }

        public int? BezPrimGola { get; set; }

        public int? ZutiKartoni { get; set; }

        public int? CrveniKartoni { get; set; }

        public double? ProsjecnaOcjena { get; set; }

        public double? OcjenaZadUtak { get; set; }

        public bool? Izbrisan { get; set; }

        public virtual Korisnik? Korisnik { get; set; }
    }
}


