using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class BolestUpdateRequest
    {
        public string? SifraPovrede { get; set; }

        public string? TipPovrede { get; set; }

        public int? TrajanjePovredeDani { get; set; }
    }
}
