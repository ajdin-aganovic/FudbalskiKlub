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
    public class PozicijaService :
        BaseCRUDService<Model.Pozicija, Database1.Pozicija, PozicijaSearchObject, PozicijaInsertRequest, PozicijaUpdateRequest>, IPozicijaService

    {
        public PozicijaService(MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database1.Pozicija> AddFilter(IQueryable<Database1.Pozicija> query, PozicijaSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.NazivPozicije))
            {
                filteredQuery = filteredQuery.Where(x => x.NazivPozicije.Contains(search.NazivPozicije));
            }
            if (!string.IsNullOrWhiteSpace(search?.KategorijaPozicije))
            {
                filteredQuery = filteredQuery.Where(x => x.KategorijaPozicije.Contains(search.KategorijaPozicije));
            }

           

            return filteredQuery;
        }

        public override IQueryable<Database1.Pozicija> AddInclude(IQueryable<Database1.Pozicija> query, PozicijaSearchObject? search = null)
        {
            if (search?.IsKorisnikIncluded == true)
            {
                query = query.Include("KorisnikPozicijas.Korisnik");
            }
            return base.AddInclude(query, search);
        }
    }
}
