using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Database1;

public partial class Stadion
{
    public int StadionId { get; set; }

    public string? NazivStadiona { get; set; }

    public int? KapacitetStadiona { get; set; }
    public bool? Izbrisan { get; set; }

    public virtual ICollection<Termin> Termins { get; set; } = new List<Termin>();

    public virtual ICollection<TreningStadion> TreningStadions { get; set; } = new List<TreningStadion>();
}
