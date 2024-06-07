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
    //[Authorize]
    //[Authorize(Roles = "Administrator, Glavni trener, Doktor")]
    [AllowAnonymous]

    public class BolestController :
        BaseCRUDController<
            Bolest,
            Model.SearchObjects.BolestSearchObject, Model.Requests.BolestInsertRequest, Model.Requests.BolestUpdateRequest>
    {
        public BolestController(ILogger<BaseController<Bolest, Model.SearchObjects.BolestSearchObject>> logger, IBolestService service) : base(logger, service)
        {

        }

    }
}
