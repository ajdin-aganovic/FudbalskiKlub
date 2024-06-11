using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Model
{
    public partial class Trening
    {
        public int TreningId { get; set; }

        public string? NazivTreninga { get; set; }

        public string? TipTreninga { get; set; }
        public bool? Izbrisan { get; set; }


        public virtual ICollection<TreningStadion> TreningStadions { get; set; } = new List<TreningStadion>();
    }
}


