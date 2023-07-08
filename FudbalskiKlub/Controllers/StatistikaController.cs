using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Model;
using Microsoft.AspNetCore.Mvc;

namespace FudbalskiKlub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatistikaController :
        BaseCRUDController<
            Statistika,
            Model.SearchObjects.StatistikaSearchObject, Model.Requests.StatistikaInsertRequest, Model.Requests.StatistikaUpdateRequest>
    {
        public StatistikaController(ILogger<BaseController<Statistika, Model.SearchObjects.StatistikaSearchObject>> logger, IStatistikaService service) : base(logger, service)
        {

        }

    }
}
