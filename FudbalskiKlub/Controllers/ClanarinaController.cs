using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Model;
using Microsoft.AspNetCore.Mvc;

namespace FudbalskiKlub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClanarinaController :
        BaseCRUDController<
            Clanarina,
            Model.SearchObjects.ClanarinaSearchObject, Model.Requests.ClanarinaInsertRequest, Model.Requests.ClanarinaUpdateRequest>
    {
        public ClanarinaController(ILogger<BaseController<Clanarina, Model.SearchObjects.ClanarinaSearchObject>> logger, IClanarinaService service) : base(logger, service)
        {

        }

    }
}
