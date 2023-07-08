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
    public class BolestService :
        BaseCRUDService<Model.Bolest, Database1.Bolest, BolestSearchObject, BolestInsertRequest, BolestUpdateRequest>, IBolestService

    {
        public BolestService(MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database1.Bolest> AddFilter(IQueryable<Database1.Bolest> query, BolestSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.SifraPovrede))
            {
                filteredQuery = filteredQuery.Where(x => x.SifraPovrede.Contains(search.SifraPovrede));
            } if (!string.IsNullOrWhiteSpace(search?.TipPovrede))
            {
                filteredQuery = filteredQuery.Where(x => x.TipPovrede.Contains(search.TipPovrede));
            }

            return filteredQuery;
        }

        public override IQueryable<Database1.Bolest> AddInclude(IQueryable<Database1.Bolest> query, BolestSearchObject? search = null)
        {
            if (search?.IsKorisnikIncluded == true)
            {
                query = query.Include("KorisnikBolests.Korisnik");
            }
            return base.AddInclude(query, search);
        }
    }
}
