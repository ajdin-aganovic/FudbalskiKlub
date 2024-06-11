using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Database1;

public partial class Bolest
{
    public int BolestId { get; set; }

    public string? SifraPovrede { get; set; }

    public string? TipPovrede { get; set; }

    public int? TrajanjePovredeDani { get; set; }
    public bool? Izbrisan { get; set; }

    public virtual ICollection<KorisnikBolest> KorisnikBolests { get; set; } = new List<KorisnikBolest>();
}
