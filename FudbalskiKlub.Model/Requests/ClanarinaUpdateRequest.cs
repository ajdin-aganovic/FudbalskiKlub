using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class ClanarinaUpdateRequest
    {

        public int? KorisnikId { get; set; }
        public double? IznosClanarine { get; set; }

        public double? Dug { get; set; }
        public bool? Placena { get; set; }
        public DateTime? DatumPlacanja { get; set; }

    }
}
