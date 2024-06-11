using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Database1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services
{
    public interface IKorisnikService : ICRUDService<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest>
    {
        Model.Korisnik changePassword(int id, KorisnikChangePasswordRequest kcpr);
        public Task<Model.Korisnik> Delete(int id);
        public Task<Model.Korisnik> Login(string username, string password);

    }
}
