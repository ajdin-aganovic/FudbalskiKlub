using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Database1;
using FudbalskiKlub.Services.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Cryptography;
using System.Text;

namespace FudbalskiKlub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(Roles = "Administrator, Glavni trener, Pomoćni trener, Igrač, Doktor")]
    //[Authorize(Roles = "Igrač")]
    [Authorize]
    public class KorisnikPozicijaController : 
        BaseCRUDController<
            Services.Model.KorisnikPozicija, 
            Model.SearchObjects.KorisnikPozicijaSearchObject, Model.Requests.KorisnikPozicijaInsertRequest, Model.Requests.KorisnikPozicijaUpdateRequest>
    {
        public KorisnikPozicijaController(ILogger<BaseController<Services.Model.KorisnikPozicija, Model.SearchObjects.KorisnikPozicijaSearchObject>> logger, IKorisnikPozicijaService service) : base(logger, service)
        {

        }
        MiniafkContext kontekst = new MiniafkContext();


    }
}
