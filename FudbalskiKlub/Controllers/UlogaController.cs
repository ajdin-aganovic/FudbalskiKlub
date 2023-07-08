using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Model;
using Microsoft.AspNetCore.Mvc;

namespace FudbalskiKlub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UlogaController :
        BaseCRUDController<
            Uloga,
            Model.SearchObjects.UlogaSearchObject, Model.Requests.UlogaInsertRequest, Model.Requests.UlogaUpdateRequest>
    {
        public UlogaController(ILogger<BaseController<Uloga, Model.SearchObjects.UlogaSearchObject>> logger, IUlogaService service) : base(logger, service)
        {

        }

    }
}
