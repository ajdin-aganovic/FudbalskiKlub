using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FudbalskiKlub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Administrator")]
    public class TransakcijskiRacunController:
        BaseCRUDController<
            TransakcijskiRacun,
            TransakcijskiRacunSearchObject,
            TransakcijskiRacunInsertRequest,
            TransakcijskiRacunUpdateRequest
            >
    {
        public TransakcijskiRacunController(ILogger<BaseController<TransakcijskiRacun, Model.SearchObjects.TransakcijskiRacunSearchObject>> logger, ITransakcijskiRacunService service) : base(logger, service)
        {

        }
    }
}
