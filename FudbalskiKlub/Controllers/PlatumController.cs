using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Model;
using Microsoft.AspNetCore.Mvc;

namespace FudbalskiKlub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatumController : BaseCRUDController<Platum, Model.SearchObjects.PlatumSearchObject, Model.Requests.PlatumInsertRequest, Model.Requests.PlatumUpdateRequest>
    {
        public PlatumController(ILogger<BaseController<Platum, Model.SearchObjects.PlatumSearchObject>> logger, IPlatumService service) : base(logger, service)
        {
            
        }


        [HttpPut("{id}/activate")]
        public virtual async Task<Platum> Activate(int id)
        {
            return await (_service as IPlatumService).Activate(id);
        }

        [HttpPut("{id}/hide")]
        public virtual async Task<Platum> Hide(int id)
        {
            return await (_service as IPlatumService).Hide(id);
        }


        [HttpGet("{id}/allowedActions")]
        public virtual async Task<List<string>> AllowedActions(int id)
        {
            return await (_service as IPlatumService).AllowedActions(id);
        }

        //[HttpGet("{id}/recommend")]
        //public virtual List<Platum> Recommend(int id)
        //{
        //    return (_service as IPlatumService).Recommend(id);
        //}

    }
}
