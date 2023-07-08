using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.SearchObjects
{
    public class TransakcijskiRacunSearchObject : BaseSearchObject
    {
        public string? BrojRacuna { get; set; }
        public bool? IsPlataIncluded { get; set; }
        public bool? IsKorisnikIncluded { get; set; }
    }
}
