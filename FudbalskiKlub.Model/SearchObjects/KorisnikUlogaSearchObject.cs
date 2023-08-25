using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.SearchObjects
{
    public class KorisnikUlogaSearchObject:BaseSearchObject
    {
        public bool? IsKorisnikIncluded { get; set; }
        public bool? IsUlogaIncluded { get; set; }
    }
}
