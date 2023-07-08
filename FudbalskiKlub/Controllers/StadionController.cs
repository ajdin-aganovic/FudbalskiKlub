using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Model;
using Microsoft.AspNetCore.Mvc;

namespace FudbalskiKlub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StadionController :
        BaseCRUDController<
            Stadion,
            Model.SearchObjects.StadionSearchObject, Model.Requests.StadionInsertRequest, Model.Requests.StadionUpdateRequest>
    {
        public StadionController(ILogger<BaseController<Stadion, Model.SearchObjects.StadionSearchObject>> logger, IStadionService service) : base(logger, service)
        {

        }

    }
}
