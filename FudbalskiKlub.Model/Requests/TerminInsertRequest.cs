using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class TerminInsertRequest
    {
        public string? SifraTermina { get; set; }

        public string? TipTermina { get; set; }

        public int? StadionId { get; set; }
        public string? Rezultat { get; set; }

    }
}
