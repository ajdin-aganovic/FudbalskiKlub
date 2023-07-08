using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.SearchObjects
{
    public class PozicijaSearchObject:BaseSearchObject
    {
        public string? NazivPozicije { get; set; }

        public string? KategorijaPozicije { get; set; }
        public bool? IsKorisnikIncluded { get; set; }

    }
}
