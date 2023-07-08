using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class PlatumUpdateRequest
    {
        public int? TransakcijskiRacunId { get; set; }

        public double? Iznos { get; set; }

        public DateTime? DatumSlanja { get; set; }
    }
}
