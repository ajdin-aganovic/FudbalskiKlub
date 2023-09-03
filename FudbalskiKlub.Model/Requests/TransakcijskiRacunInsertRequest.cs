using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class TransakcijskiRacunInsertRequest
    {

        public string? BrojRacuna { get; set; }

        public string? AdresaPrebivalista { get; set; }

        public string? NazivBanke { get; set; }
        public int? KorisnikId { get; set; }

    }
}
