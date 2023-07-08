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
    public class ClanarinaService :
        BaseCRUDService<Model.Clanarina, Database1.Clanarina, ClanarinaSearchObject, ClanarinaInsertRequest, ClanarinaUpdateRequest>, IClanarinaService

    {
        public ClanarinaService(MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<Database1.Clanarina> AddFilter(IQueryable<Database1.Clanarina> query, ClanarinaSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.MinIznosClanarine.ToString()))
            {
                filteredQuery = filteredQuery.Where(x => x.IznosClanarine>search.MinIznosClanarine);
            }
            if (!string.IsNullOrWhiteSpace(search?.MaxIznosClanarine.ToString()))
            {
                filteredQuery = filteredQuery.Where(x => x.IznosClanarine < search.MaxIznosClanarine);
            }

            return filteredQuery;
        }
    }
}
