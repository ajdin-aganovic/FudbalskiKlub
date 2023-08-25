using AutoMapper;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Database1;
using FudbalskiKlub.Services.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services
{
    public class KorisnikUlogaService :
        BaseCRUDService<Model.KorisnikUloga, Database1.KorisnikUloga, KorisnikUlogaSearchObject, KorisnikUlogaInsertRequest, KorisnikUlogaUpdateRequest>, IKorisnikUlogaService
    {
        public KorisnikUlogaService(MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
        }

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

        public override IQueryable<Database1.KorisnikUloga> AddInclude(IQueryable<Database1.KorisnikUloga> query, KorisnikUlogaSearchObject? search = null)
        {
            if (search?.IsKorisnikIncluded == true)
            {
                query = query.Include("Korisnik");
            }
            if (search?.IsUlogaIncluded == true)
            {
                query = query.Include("Uloga");
            }
            return base.AddInclude(query, search);
        }

        //public async Task<Model.KorisnikUloga> Login(string username, string password)
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

        //    return _mapper.Map<Model.KorisnikUloga>(entity);
        //}

    }
}
