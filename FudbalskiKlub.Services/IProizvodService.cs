using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services
{
    public interface IProizvodService:ICRUDService<Model.Proizvod, ProizvodSearchObject, ProizvodInsertRequest, ProizvodUpdateRequest>
    {
        List<Model.Proizvod> Recommend(int id);

    }
}
