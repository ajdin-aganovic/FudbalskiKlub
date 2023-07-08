using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class StadionUpdateRequest
    {
        public string? NazivStadiona { get; set; }

        public int? KapacitetStadiona { get; set; }
    }
}
