using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Database1;

public partial class Proizvod
{
    public int ProizvodId { get; set; }

    public string? Naziv { get; set; }

    public string? Sifra { get; set; }

    public string? Kategorija { get; set; }

    public double? Cijena { get; set; }

    public int? Kolicina { get; set; }
    public bool? Izbrisan { get; set; }
    public string? StateMachine { get; set; }

    public virtual ICollection<NarudzbaStavke> NarudzbaStavkes { get; set; } = new List<NarudzbaStavke>();
}
