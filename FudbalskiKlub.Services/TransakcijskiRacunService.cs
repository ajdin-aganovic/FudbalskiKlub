using AutoMapper;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Database1;
using FudbalskiKlub.Services.ProizvodiStateMachine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services
{
    public class TransakcijskiRacunService:
        BaseCRUDService<Model.TransakcijskiRacun, Database1.TransakcijskiRacun, TransakcijskiRacunSearchObject, TransakcijskiRacunInsertRequest, TransakcijskiRacunUpdateRequest>, ITransakcijskiRacunService

    {
        public TransakcijskiRacunService(MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database1.TransakcijskiRacun> AddFilter(IQueryable<Database1.TransakcijskiRacun> query, TransakcijskiRacunSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.BrojRacuna))
            {
                filteredQuery = filteredQuery.Where(x => x.BrojRacuna.Contains(search.BrojRacuna));
            }
            
            return filteredQuery;
        }

        public override IQueryable<Database1.TransakcijskiRacun> AddInclude(IQueryable<Database1.TransakcijskiRacun> query, TransakcijskiRacunSearchObject? search = null)
        {
            if (search?.IsPlataIncluded == true)
            {
                query = query.Include("Plata");
            }
            if (search?.IsKorisnikIncluded == true)
            {
                query = query.Include("KorisnikTransakcijskiRacuns.Korisnik");
            }
            return base.AddInclude(query, search);
        }
    }
}
