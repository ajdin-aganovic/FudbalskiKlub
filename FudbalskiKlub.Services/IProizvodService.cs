using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services
{
    public interface IProizvodService:ICRUDService<Model.Proizvod, ProizvodSearchObject, ProizvodInsertRequest, ProizvodUpdateRequest>
    {
        Task<Proizvod> Activate(int id);
        Task<List<string>> AllowedActions(int id);
        Task<Proizvod> Hide(int id);
        List<Model.Proizvod> Recommend(int id);

    }
}
