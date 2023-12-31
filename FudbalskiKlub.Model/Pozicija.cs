﻿using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Model
{
    public partial class Pozicija
    {
        public int PozicijaId { get; set; }

        public string? NazivPozicije { get; set; }

        public string? KategorijaPozicije { get; set; }

        public virtual ICollection<KorisnikPozicija> KorisnikPozicijas { get; set; } = new List<KorisnikPozicija>();
    }

}