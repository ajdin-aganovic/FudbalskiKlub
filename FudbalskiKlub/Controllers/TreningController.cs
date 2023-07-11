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
    [Authorize(Roles = "Administrator, Glavni trener, Pomoćni trener, Kondicioni trener")]
    public class TreningController :
        BaseCRUDController<
            Trening,
            Model.SearchObjects.TreningSearchObject, Model.Requests.TreningInsertRequest, Model.Requests.TreningUpdateRequest>
    {
        public TreningController(ILogger<BaseController<Trening, Model.SearchObjects.TreningSearchObject>> logger, ITreningService service) : base(logger, service)
        {

        }

    }
}
