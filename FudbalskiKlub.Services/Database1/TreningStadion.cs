using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Database1;

public partial class TreningStadion
{
    public int TreningStadionId { get; set; }

    public int? TreningId { get; set; }

    public int? StadionId { get; set; }

    public virtual Stadion? Stadion { get; set; }

    public virtual Trening? Trening { get; set; }
}
