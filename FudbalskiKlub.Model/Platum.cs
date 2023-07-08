using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services.Model
{

    public partial class Platum
    {
        public int PlataId { get; set; }

        public int? TransakcijskiRacunId { get; set; }

        public string? StateMachine { get; set; }

        public double? Iznos { get; set; }

        public DateTime? DatumSlanja { get; set; }
        public virtual TransakcijskiRacun? TransakcijskiRacun { get; set; }

    }
}
