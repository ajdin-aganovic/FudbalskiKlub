using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Model
{
    public partial class Uloga
    {
        public int UlogaId { get; set; }

        public string? NazivUloge { get; set; }

        public string? PodtipUloge { get; set; }
        public bool? Izbrisan { get; set; }

        //public virtual ICollection<KorisnikUloga> KorisnikUlogas { get; set; } = new List<KorisnikUloga>();

    }

}