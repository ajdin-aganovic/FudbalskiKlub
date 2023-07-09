using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FudbalskiKlub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class PozicijaController :
        BaseCRUDController<
            Pozicija,
            Model.SearchObjects.PozicijaSearchObject, Model.Requests.PozicijaInsertRequest, Model.Requests.PozicijaUpdateRequest>
    {
        public PozicijaController(ILogger<BaseController<Pozicija, Model.SearchObjects.PozicijaSearchObject>> logger, IPozicijaService service) : base(logger, service)
        {

        }

    }
}
