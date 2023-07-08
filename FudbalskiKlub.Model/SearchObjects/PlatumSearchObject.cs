using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.SearchObjects
{
    public class PlatumSearchObject:BaseSearchObject
    {
        public string? StateMachine { get; set; }

        public double? MaxIznos { get; set; }
        public double? MinIznos { get; set; }

        public bool? IsTransakcijskiRacunIncluded { get; set; }
    }
}
