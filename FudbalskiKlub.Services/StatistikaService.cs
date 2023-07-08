using AutoMapper;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Database1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services
{
    public class StatistikaService :
        BaseCRUDService<Model.Statistika, Database1.Statistika, StatistikaSearchObject, StatistikaInsertRequest, StatistikaUpdateRequest>, IStatistikaService

    {
        public StatistikaService(MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database1.Statistika> AddInclude(IQueryable<Database1.Statistika> query, StatistikaSearchObject? search = null)
        {
            if (search?.IsKorisnikIncluded == true)
            {
                query = query.Include("Korisnik");
            }
            return base.AddInclude(query, search);
        }
    }
}
