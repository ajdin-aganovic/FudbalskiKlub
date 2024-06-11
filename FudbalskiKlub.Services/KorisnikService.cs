using AutoMapper;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Database1;
using FudbalskiKlub.Services.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FudbalskiKlub.Services
{
    public class KorisnikService:
        BaseCRUDService<Model.Korisnik, Database1.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest>, IKorisnikService
    {

        public KorisnikService(MiniafkContext context, IMapper mapper) : base(context, mapper)
        {

        }

        //public async Task<Model.Korisnik> Login(string username, string password)
        //{
        //    var entity = await _context.Korisniks.FirstOrDefaultAsync(x => x.KorisnickoIme == username);
        //    var hash = GenerateHash(entity.LozinkaSalt, password);
        //    if (entity == null)
        //    {
        //        return null;
        //    }
        //    if(hash!=entity.LozinkaHash)
        //    {
        //        return null;

        //    }
        //    return _mapper.Map<Model.Korisnik>(entity);
        //}



        public Model.Korisnik changePassword(int id, KorisnikChangePasswordRequest kcpr)
        {
            var pronadjeni = _context.Korisniks.Find(id);
            if (pronadjeni == null)
            {
                throw new NotImplementedException("Loš id");
            }
            else
            {
                var saltirani = GenerateSalt();
                var novi = GenerateHash(saltirani, kcpr.Password);
                pronadjeni.LozinkaHash = novi;
                pronadjeni.LozinkaSalt = saltirani;
            }

            _context.SaveChanges();
            return _mapper.Map<Model.Korisnik>(pronadjeni);
        }

        public override async Task BeforeInsert(Database1.Korisnik entity, KorisnikInsertRequest insert)
        {
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, insert.Password);
        }

        public override async Task BeforeUpdate(Database1.Korisnik entity, KorisnikUpdateRequest update)
        {
        //    entity.LozinkaSalt = GenerateSalt();
        //    entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, update.Password);
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

        public async override Task<Model.Korisnik> Delete(int id)
        {
            var set = _context.Set<Database1.Korisnik>();

            var entity = set.Find(id);

            if(entity==null)
            {
                throw new Exception("Nije pronađen user");
            }
            entity.Izbrisan = true;
            await _context.SaveChangesAsync();


            return _mapper.Map<Model.Korisnik>(entity);
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
            if(!string.IsNullOrWhiteSpace(search?.Uloga))
            {
                filteredQuery = filteredQuery.Where(x => x.Uloga.Contains(search.Uloga));
            }

            if(search.IsDeleted.HasValue)
            {
                filteredQuery = filteredQuery.Where(x => x.Izbrisan == search.IsDeleted);
            }
            return filteredQuery;
        }

        public override IQueryable<Database1.Korisnik> AddInclude(IQueryable<Database1.Korisnik> query, KorisnikSearchObject? search = null)
        {
            if (search?.IsUlogaIncluded == true)
            {
                //query = query.Include("KorisnikUlogas.Uloga");
                query = query.Include(x => x.KorisnikUlogas).ThenInclude(x => x.Uloga); //jednostavniji način

            }
            if (search?.IsTransakcijskiRacunIncluded == true)
            {
                query = query.Include("KorisnikTransakcijskiRacuns");
            }
            if(search?.IsClanarinaIncluded==true)
            {
                query = query.Include("Clanarinas");
            }
            return base.AddInclude(query, search);
        }

        public async Task<Model.Korisnik> Login(string username, string password)
        {
            var entity = await _context.Korisniks.Include("KorisnikUlogas.Uloga").FirstOrDefaultAsync(x => x.KorisnickoIme == username);

            if (entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.LozinkaSalt!, password);

            if (hash != entity.LozinkaHash)
            {
                return null;
            }

            return _mapper.Map<Model.Korisnik>(entity);
        }

        static MLContext mlContext = null;
        static object isLocked = new object();
        static ITransformer model = null;

        public List<Model.Korisnik> Recommend(int id)
        {
            lock (isLocked)
            {
                if (mlContext == null)
                {
                    mlContext = new MLContext();

                    var tmpData = _context.Statistikas.ToList();

                    var data = new List<ProductEntry>();


                    //foreach (var x in tmpData)
                    //{

                    //    var distinctItemId = x.Sta.Select(y => y.Korisnik).ToList();

                    //    distinctItemId.ForEach(y =>
                    //        {
                    //            var relatedItems = x.NarudzbaStavkes.Where(z => z.ProizvodId != y);

                    //            foreach (var z in relatedItems)
                    //            {
                    //                data.Add(new ProductEntry()
                    //                {
                    //                    ProductID = (uint)y,
                    //                    CoPurchaseProductID = (uint)z.ProizvodId,
                    //                });
                    //            }
                    //        );
                    //    }
                    //}


                    var traindata = mlContext.Data.LoadFromEnumerable(data);

                    //STEP 3: Your data is already encoded so all you need to do is specify options for MatrxiFactorizationTrainer with a few extra hyperparameters
                    //        LossFunction, Alpa, Lambda and a few others like K and C as shown below and call the trainer.
                    MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                    options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
                    options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
                    options.LabelColumnName = "Label";
                    options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                    options.Alpha = 0.01;
                    options.Lambda = 0.025;
                    // For better results use the following parameters
                    options.NumberOfIterations = 100;
                    options.C = 0.00001;

                    var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                    model = est.Fit(traindata);

                }
            }




            //prediction

            var products = _context.Korisniks.Where(x => x.KorisnikId != id);

            var predictionResult = new List<Tuple<Database1.Korisnik, float>>();

            foreach (var product in products)
            {

                var predictionengine = mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                var prediction = predictionengine.Predict(
                                         new ProductEntry()
                                         {
                                             ProductID = (uint)id,
                                             CoPurchaseProductID = (uint)product.KorisnikId
                                         });


                predictionResult.Add(new Tuple<Database1.Korisnik, float>(product, prediction.Score));
            }


            var finalResult = predictionResult.OrderByDescending(x => x.Item2).Select(x => x.Item1).Take(3).ToList();

            return _mapper.Map<List<Model.Korisnik>>(finalResult);

        }

    }

    public class Copurchase_prediction
    {
        public float Score { get; set; }
    }

    public class ProductEntry
    {
        [KeyType(count: 10)]
        public uint ProductID { get; set; }

        [KeyType(count: 10)]
        public uint CoPurchaseProductID { get; set; }

        public float Label { get; set; }
    }

}
