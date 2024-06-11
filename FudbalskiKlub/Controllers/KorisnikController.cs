using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Database1;
using FudbalskiKlub.Services.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace FudbalskiKlub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(Roles = "Administrator, Glavni trener, Pomoćni trener, Igrač, Doktor")]
    //[Authorize(Roles = "Igrač")]
    [Authorize]
    public class KorisnikController : 
        BaseCRUDController<
            Services.Model.Korisnik, 
            Model.SearchObjects.KorisnikSearchObject, Model.Requests.KorisnikInsertRequest, Model.Requests.KorisnikUpdateRequest>
    {
        public KorisnikController(ILogger<BaseController<Services.Model.Korisnik, Model.SearchObjects.KorisnikSearchObject>> logger, IKorisnikService service) : base(logger, service)
        {

        }
        MiniafkContext kontekst = new MiniafkContext();


        //public async Task<Model.Korisnik> Login(string username, string password)
        //{
        //    var entity = await _context.KorisnikUlogas.FirstOrDefaultAsync(x => x.Korisnik.KorisnickoIme == username);

        //    if (entity == null)
        //    {
        //        return null;
        //    }

        //    var hash = GenerateHash(entity.Korisnik.LozinkaSalt!, password);

        //    if (hash != entity.Korisnik.LozinkaHash)
        //    {
        //        return null;
        //    }

        //    return _mapper.Map<Model.Korisnik>(entity);
        //}

        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);


            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        [HttpPut("passwordChange/{id}")]
        public Services.Model.Korisnik changePassword(int id, KorisnikChangePasswordRequest kcpr)

        {
            _logger.LogInformation("Korisnik zatražio promjenu passworda" + DateTime.Now);
            return (_service as IKorisnikService).changePassword(id, kcpr);

        }


        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginRequest model)
        //{

        //}

        //[HttpPost("login")]
        //public Services.Model.Korisnik Login (string username, string password)
        //{
        //    return (_service as IKorisnikService).Login(username, password);
        //}

        //[HttpGet()]
        //public async Task<Services.Database1.Korisnik> Get([FromQuery] KorisnikSearchObject? search = null)
        //{
        //    return await (_service as Korisnik).Get(search);
        //}
    }
}
