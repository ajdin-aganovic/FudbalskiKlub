using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Database1;

public partial class KorisnikPozicija
{
    public int KorisnikPozicijaId { get; set; }

    public int? KorisnikId { get; set; }

    public int? PozicijaId { get; set; }

    public virtual Korisnik? Korisnik { get; set; }

    public virtual Pozicija? Pozicija { get; set; }
}
