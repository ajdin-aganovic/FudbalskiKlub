using FudbalskiKlub.Model;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Model;
using FudbalskiKlub.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services
{
    public interface IPlatumService : ICRUDService<Platum, PlatumSearchObject, PlatumInsertRequest, PlatumUpdateRequest>
    {
        Task<Platum> Activate(int id);

        Task<Platum> Hide(int id);

        Task<List<string>> AllowedActions(int id);

        //List<Model.Platum> Recommend(int id);
    }
}
