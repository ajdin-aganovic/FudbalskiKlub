using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Database1;

public partial class Pozicija
{
    public int PozicijaId { get; set; }

    public string? NazivPozicije { get; set; }

    public string? KategorijaPozicije { get; set; }
    public bool? Izbrisan { get; set; }

    public virtual ICollection<KorisnikPozicija> KorisnikPozicijas { get; set; } = new List<KorisnikPozicija>();
}
