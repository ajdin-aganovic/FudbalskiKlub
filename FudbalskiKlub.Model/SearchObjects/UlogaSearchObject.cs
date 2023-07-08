using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.SearchObjects
{
    public class UlogaSearchObject:BaseSearchObject
    {
        public string? NazivUloge { get; set; }
        public bool? IsKorisnikIncluded { get; set; }

    }
}
