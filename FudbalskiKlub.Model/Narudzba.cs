using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Model
{
    public partial class Narudzba
    {
        public int NarudzbaId { get; set; }

        public string? BrojNarudzba { get; set; }

        public DateTime? Datum { get; set; }

        public string? Status { get; set; }
        public virtual ICollection<NarudzbaStavke> NarudzbaStavkes { get; } = new List<NarudzbaStavke>();

    }

}

