using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.SearchObjects
{
    public class TerminSearchObject:BaseSearchObject
    {
        public string? SifraTermina { get; set; }

        public string? TipTermina { get; set; }

        //public int? StadionId { get; set; }
        public bool? IsStadionIncluded { get; set; }

    }
}
