using AutoMapper;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Database1;
using FudbalskiKlub.Services.Model;
using FudbalskiKlub.Services.ProizvodiStateMachine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services
{
    public class KorisnikService:
        BaseCRUDService<Model.Korisnik, Database1.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest>, IKorisnikService
    {
        public KorisnikService(MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override async Task BeforeInsert(Database1.Korisnik entity, KorisnikInsertRequest insert)
        {
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, insert.Password);
        }

        public override async Task BeforeUpdate(Database1.Korisnik entity, KorisnikUpdateRequest update)
        {

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, update.Password);
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

        public override IQueryable<Database1.Korisnik> AddFilter(IQueryable<Database1.Korisnik> query, KorisnikSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.KorisnickoIme))
            {
                filteredQuery = filteredQuery.Where(x => x.KorisnickoIme.Contains(search.KorisnickoIme));
            }

            if (!string.IsNullOrWhiteSpace(search?.StrucnaSprema))
            {
                filteredQuery = filteredQuery.Where(x => x.StrucnaSprema.Contains(search.StrucnaSprema));
            }


            if (search.PodUgovorom.HasValue)
            {
                filteredQuery = filteredQuery.Where(x => x.PodUgovorom==search.PodUgovorom);
            }
            return filteredQuery;
        }

        public override IQueryable<Database1.Korisnik> AddInclude(IQueryable<Database1.Korisnik> query, KorisnikSearchObject? search = null)
        {
            if (search?.IsUlogaIncluded == true)
            {
                query = query.Include("KorisnikUlogas.Uloga");
            }
            if (search?.IsTransakcijskiRacunIncluded == true)
            {
                query = query.Include("KorisnikTransakcijskiRacuns.TransakcijskiRacun");
            }
            if(search?.IsClanarinaIncluded==true)
            {
                query = query.Include("Clanarinas");
            }
            if (search?.IsBolestIncluded == true)
            {
                query = query.Include("KorisnikBolests.Bolest");
            }
            return base.AddInclude(query, search);
        }

        public async Task<Model.Korisnik>Login(string username, string password)
        {
            var entity = await _context.Korisniks.Include("KorisnikUlogas.Uloga").FirstOrDefaultAsync(x => x.KorisnickoIme == username);

            if(entity==null)
            {
                return null;
            }

            var hash = GenerateHash(entity.LozinkaSalt, password);

            if(hash!=entity.LozinkaHash)
            {
                return null;
            }
            return _mapper.Map<Model.Korisnik>(entity);
        }

    }
}
