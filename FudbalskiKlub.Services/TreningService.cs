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
    public class TreningService :
        BaseCRUDService<Model.Trening, Database1.Trening, TreningSearchObject, TreningInsertRequest, TreningUpdateRequest>, ITreningService

    {
        public TreningService(MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database1.Trening> AddFilter(IQueryable<Database1.Trening> query, TreningSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.NazivTreninga))
            {
                filteredQuery = filteredQuery.Where(x => x.NazivTreninga.Contains(search.NazivTreninga));
            }
            if (!string.IsNullOrWhiteSpace(search?.TipTreninga))
            {
                filteredQuery = filteredQuery.Where(x => x.TipTreninga.Contains(search.TipTreninga));
            }
            return filteredQuery;
        }

        public override IQueryable<Database1.Trening> AddInclude(IQueryable<Database1.Trening> query, TreningSearchObject? search = null)
        {
            if (search?.IsStadionIncluded == true)
            {
                query = query.Include("TreningStadions");
            }
            return base.AddInclude(query, search);
        }
    }
}
