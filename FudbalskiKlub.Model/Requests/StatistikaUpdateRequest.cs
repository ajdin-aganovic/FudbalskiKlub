using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class StatistikaUpdateRequest
    {
        public int? Golovi { get; set; }

        public int? Asistencije { get; set; }

        public bool? IgracMjeseca { get; set; }

        public int? BezPrimGola { get; set; }

        public int? ZutiKartoni { get; set; }

        public int? CrveniKartoni { get; set; }

        public double? ProsjecnaOcjena { get; set; }

        public double? OcjenaZadUtak { get; set; }

    }
}
