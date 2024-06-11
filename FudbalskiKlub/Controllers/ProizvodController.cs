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

        [HttpPut("{id}/activate")]
        public virtual async Task<Proizvod> Activate(int id)
        {
            return await (_service as IProizvodService).Activate(id);
        }

        [HttpPut("{id}/hide")]
        public virtual async Task<Proizvod> Hide(int id)
        {
            return await (_service as IProizvodService).Hide(id);
        }


        [HttpGet("{id}/allowedActions")]
        public virtual async Task<List<string>> AllowedActions(int id)
        {
            return await (_service as IProizvodService).AllowedActions(id);
        }


        [HttpGet("{id}/recommend")]
        public virtual List<Services.Model.Proizvod> Recommend(int id)
        {
            return (_service as IProizvodService).Recommend(id);
        }

    }
}
