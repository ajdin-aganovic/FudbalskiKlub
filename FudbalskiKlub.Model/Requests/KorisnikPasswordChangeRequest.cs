using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class KorisnikChangePasswordRequest
    {


        [Compare("PasswordPotvrda", ErrorMessage = "Passwords do not match.")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? PasswordPotvrda { get; set; }


    }
}
