using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Database1;

public partial class Platum
{
    public int PlataId { get; set; }

    public int? TransakcijskiRacunId { get; set; }

    public string? StateMachine { get; set; }

    public double? Iznos { get; set; }

    public DateTime? DatumSlanja { get; set; }
    public bool? Izbrisan { get; set; }

    public virtual TransakcijskiRacun? TransakcijskiRacun { get; set; }
}
