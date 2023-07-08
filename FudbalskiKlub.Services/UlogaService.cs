using AutoMapper;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Database1;
using FudbalskiKlub.Services.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services
{
    public class UlogaService :
        BaseCRUDService<Model.Uloga, Database1.Uloga, UlogaSearchObject, UlogaInsertRequest, UlogaUpdateRequest>, IUlogaService
    {
        public UlogaService(MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database1.Uloga> AddFilter(IQueryable<Database1.Uloga> query, UlogaSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.NazivUloge))
            {
                filteredQuery = filteredQuery.Where(x => x.NazivUloge.Contains(search.NazivUloge));
            }
            return filteredQuery;
        }

        public override IQueryable<Database1.Uloga> AddInclude(IQueryable<Database1.Uloga> query, UlogaSearchObject? search = null)
        {
            if (search?.IsKorisnikIncluded == true)
            {
                query = query.Include("KorisnikUlogas.Korisnik");
            }
            return base.AddInclude(query, search);
        }

    }
}
