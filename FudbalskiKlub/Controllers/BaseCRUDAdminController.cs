using FudbalskiKlub.Model;
using FudbalskiKlub.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FudbalskiKlub.Controllers
{

    [Route("[controller]")]
    public class BaseCRUDAdminController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch> where T : class where TSearch : class
    {
        protected new readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service;
        protected new readonly ILogger<BaseController<T, TSearch>> _logger;

        public BaseCRUDAdminController(ILogger<BaseController<T, TSearch>> logger, ICRUDService<T, TSearch, TInsert, TUpdate> service)
            : base(logger, service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]

        public virtual async Task<T> Insert([FromBody]TInsert insert)
        {
            return await _service.Insert(insert);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]

        public virtual async Task<T> Update(int id, [FromBody]TUpdate update)
        {
            return await _service.Update(id, update);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Administrator")]
        public virtual async Task<T> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}
