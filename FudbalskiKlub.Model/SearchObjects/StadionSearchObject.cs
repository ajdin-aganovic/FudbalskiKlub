using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.SearchObjects
{
    public class StadionSearchObject:BaseSearchObject
    {
        public string? NazivStadiona { get; set; }

        public int? MaxKapacitetStadiona { get; set; }
        public int? MinKapacitetStadiona { get; set; }

    }
}
