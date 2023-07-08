using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Model;
using Microsoft.AspNetCore.Mvc;

namespace FudbalskiKlub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TerminController :
        BaseCRUDController<
            Termin,
            Model.SearchObjects.TerminSearchObject, Model.Requests.TerminInsertRequest, Model.Requests.TerminUpdateRequest>
    {
        public TerminController(ILogger<BaseController<Termin, Model.SearchObjects.TerminSearchObject>> logger, ITerminService service) : base(logger, service)
        {

        }



    }
}
