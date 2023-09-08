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
    public class KorisnikPozicijaService :
        BaseCRUDService<Model.KorisnikPozicija, Database1.KorisnikPozicija, KorisnikPozicijaSearchObject, KorisnikPozicijaInsertRequest, KorisnikPozicijaUpdateRequest>, IKorisnikPozicijaService

    {
        public KorisnikPozicijaService(MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
        }

        //public override IQueryable<Database1.KorisnikPozicija> AddFilter(IQueryable<Database1.KorisnikPozicija> query, KorisnikPozicijaSearchObject? search = null)
        //{
        //    var filteredQuery = base.AddFilter(query, search);

        //    if (!string.IsNullOrWhiteSpace(search?.SifraPovrede))
        //    {
        //        filteredQuery = filteredQuery.Where(x => x.SifraPovrede.Contains(search.SifraPovrede));
        //    } if (!string.IsNullOrWhiteSpace(search?.TipPovrede))
        //    {
        //        filteredQuery = filteredQuery.Where(x => x.TipPovrede.Contains(search.TipPovrede));
        //    }

        //    return filteredQuery;
        //}

        //public override IQueryable<Database1.KorisnikPozicija> AddInclude(IQueryable<Database1.KorisnikPozicija> query, KorisnikPozicijaSearchObject? search = null)
        //{
        //    if (search?.IsKorisnikIncluded == true)
        //    {
        //        query = query.Include("KorisnikPozicijas.Korisnik");
        //    }
        //    if (search?.IsPozicijaIncluded == true)
        //    {
        //        query = query.Include("KorisnikPozicijas.Pozicija");
        //    }
        //    return base.AddInclude(query, search);
        //}
    }
}
