using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Model;
using Microsoft.AspNetCore.Mvc;

namespace FudbalskiKlub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodController :
        BaseCRUDController<
            Proizvod,
            Model.SearchObjects.ProizvodSearchObject, Model.Requests.ProizvodInsertRequest, Model.Requests.ProizvodUpdateRequest>
    {
        public ProizvodController(ILogger<BaseController<Proizvod, Model.SearchObjects.ProizvodSearchObject>> logger, IProizvodService service) : base(logger, service)
        {

        }

        [HttpGet("{id}/recommend")]
        public virtual List<Services.Model.Proizvod> Recommend(int id)
        {
            return (_service as IProizvodService).Recommend(id);
        }

    }
}
