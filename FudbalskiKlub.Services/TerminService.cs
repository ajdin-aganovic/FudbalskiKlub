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
    public class TerminService :
        BaseCRUDService<Model.Termin, Database1.Termin, TerminSearchObject, TerminInsertRequest, TerminUpdateRequest>, ITerminService

    {
        public TerminService(MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database1.Termin> AddFilter(IQueryable<Database1.Termin> query, TerminSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.TipTermina))
            {
                filteredQuery = filteredQuery.Where(x => x.TipTermina.Contains(search.TipTermina));
            }
            if (!string.IsNullOrWhiteSpace(search?.SifraTermina))
            {
                filteredQuery = filteredQuery.Where(x => x.SifraTermina.Contains(search.SifraTermina));
            }


            return filteredQuery;
        }

        public override IQueryable<Database1.Termin> AddInclude(IQueryable<Database1.Termin> query, TerminSearchObject? search = null)
        {
            if (search?.IsStadionIncluded == true)
            {
                query = query.Include("Stadion");
            }

            return base.AddInclude(query, search);
        }

    }
}
