using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.SearchObjects
{
    public class StatistikaSearchObject:BaseSearchObject
    {
        public bool? IsIgracMjeseca { get; set; }
        public int? KorisnikId { get; set; }

        public bool? IsKorisnikIncluded { get; set; }

    }
}
