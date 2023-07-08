using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class PozicijaInsertRequest
    {
        public string? NazivPozicije { get; set; }

        public string? KategorijaPozicije { get; set; }
    }
}
