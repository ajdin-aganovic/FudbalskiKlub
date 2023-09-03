using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class KorisnikUpdateRequest
    {

        public string? KorisnickoIme { get; set; }

        public string? Email { get; set; }
        //[Compare("PasswordPotvrda", ErrorMessage = "Passwords do not match.")]
        //public string? Password { get; set; }

        //[Compare("Password", ErrorMessage = "Passwords do not match.")]
        //public string? PasswordPotvrda { get; set; }

        public string? StrucnaSprema { get; set; }

        public bool? PodUgovorom { get; set; }

        public DateTime? PodUgovoromOd { get; set; }

        public DateTime? PodUgovoromDo { get; set; }
        public string? Uloga { get; set; }
    }
}
