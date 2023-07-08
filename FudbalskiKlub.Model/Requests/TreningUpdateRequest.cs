using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class TreningUpdateRequest
    {
        public string? NazivTreninga { get; set; }

        public string? TipTreninga { get; set; }
    }
}
