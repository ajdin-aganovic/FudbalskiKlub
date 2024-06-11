using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class ProizvodInsertRequest
    {
        public string? Naziv { get; set; }

        public string? Sifra { get; set; }

        public string? Kategorija { get; set; }
        public double? Cijena { get; set; }
        public int? Kolicina { get; set; }
        public string? StateMachine { get; set; }

    }
}
