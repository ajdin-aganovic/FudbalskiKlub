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
    public class StadionService :
        BaseCRUDService<Model.Stadion, Database1.Stadion, StadionSearchObject, StadionInsertRequest, StadionUpdateRequest>, IStadionService

    {
        public StadionService(MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database1.Stadion> AddFilter(IQueryable<Database1.Stadion> query, StadionSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.NazivStadiona))
            {
                filteredQuery = filteredQuery.Where(x => x.NazivStadiona.Contains(search.NazivStadiona));
            }

            if (!string.IsNullOrWhiteSpace(search?.MinKapacitetStadiona.ToString()))
            {
                filteredQuery = filteredQuery.Where(x => x.KapacitetStadiona > search.MinKapacitetStadiona);
            }


            if (!string.IsNullOrWhiteSpace(search?.MaxKapacitetStadiona.ToString()))
            {
                filteredQuery = filteredQuery.Where(x => x.KapacitetStadiona < search.MaxKapacitetStadiona);
            }

            return filteredQuery;
        }
    }
}
