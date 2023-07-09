using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace FudbalskiKlub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisnikController : 
        BaseCRUDController<
            Korisnik, 
            Model.SearchObjects.KorisnikSearchObject, Model.Requests.KorisnikInsertRequest, Model.Requests.KorisnikUpdateRequest>
    {
        public KorisnikController(ILogger<BaseController<Korisnik, Model.SearchObjects.KorisnikSearchObject>> logger, IKorisnikService service) : base(logger, service)
        {

        }

        //[HttpGet()]
        //public async Task<Services.Database1.Korisnik> Get([FromQuery] KorisnikSearchObject? search = null)
        //{
        //    return await (_service as Korisnik).Get(search);
        //}
    }
}
