using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.SearchObjects
{
    public class TreningSearchObject:BaseSearchObject
    {
        public string? NazivTreninga { get; set; }

        public string? TipTreninga { get; set; }
        public bool? IsStadionIncluded { get; set; }

    }
}
