using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.SearchObjects
{
    public class BolestSearchObject:BaseSearchObject
    {
        public string? SifraPovrede { get; set; }

        public string? TipPovrede { get; set; }
        public bool? IsKorisnikIncluded { get; set; }

    }
}
