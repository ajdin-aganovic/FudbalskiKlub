using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Database1;

public partial class Clanarina
{
    public int ClanarinaId { get; set; }

    public int? KorisnikId { get; set; }

    public double? IznosClanarine { get; set; }

    public double? Dug { get; set; }

    public virtual Korisnik? Korisnik { get; set; }
}
