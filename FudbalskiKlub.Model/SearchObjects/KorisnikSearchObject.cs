using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.SearchObjects
{
    public class KorisnikSearchObject:BaseSearchObject
    {
        public string? KorisnickoIme { get; set; }
        public string? StrucnaSprema { get; set; }
        public bool? PodUgovorom { get; set; }
        public string? Uloga { get; set; }
        public bool? IsTransakcijskiRacunIncluded { get; set; }
        public bool? IsUlogaIncluded { get; set; }
        public bool? IsClanarinaIncluded { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
