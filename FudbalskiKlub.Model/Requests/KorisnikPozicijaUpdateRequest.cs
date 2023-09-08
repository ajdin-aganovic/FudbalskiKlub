using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class KorisnikPozicijaUpdateRequest
    {

        public int? KorisnikId { get; set; }

        public int? PozicijaId { get; set; }
    }
}
