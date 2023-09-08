using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.SearchObjects
{
    public class ClanarinaSearchObject:BaseSearchObject
    {
        public double? MinIznosClanarine { get; set; }
        public double? MaxIznosClanarine { get; set; }
        public bool? Placena { get; set; }

    }
}
