using AutoMapper;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Database1;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML.Trainers;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using FudbalskiKlub.Services.ProizvodStateMachine;

namespace FudbalskiKlub.Services
{
    public class ProizvodService :
        BaseCRUDService<Model.Proizvod, Database1.Proizvod, ProizvodSearchObject, ProizvodInsertRequest, ProizvodUpdateRequest>, IProizvodService

    {
        public BaseProizvodState _baseState { get; set; }
        public ProizvodService(BaseProizvodState baseState, MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
            _baseState = baseState;
        }

        public override IQueryable<Database1.Proizvod> AddFilter(IQueryable<Database1.Proizvod> query, ProizvodSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.NazivProizvoda))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv.Contains(search.NazivProizvoda));
            }
            if (!string.IsNullOrWhiteSpace(search?.SifraProizvoda))
            {
                filteredQuery = filteredQuery.Where(x => x.Sifra.Contains(search.SifraProizvoda));
            }

           

            return filteredQuery;
        }

        //public override IQueryable<Database1.Proizvod> AddInclude(IQueryable<Database1.Proizvod> query, ProizvodSearchObject? search = null)
        //{
        //    if (search?.IsKorisnikIncluded == true)
        //    {
        //        query = query.Include("KorisnikProizvods.Korisnik");
        //    }
        //    return base.AddInclude(query, search);
        //}
        static MLContext mlContext = null;
        static object isLocked = new object();
        static ITransformer model = null;

        public List<Model.Proizvod> Recommend(int id)
        {
            lock (isLocked)
            {
                if (mlContext == null)
                {
                    mlContext = new MLContext();

                    var tmpData = _context.Narudzbas.Include("NarudzbaStavkes").ToList();

                    var data = new List<ProductEntry>();


                    foreach (var x in tmpData)
                    {
                        if (x.NarudzbaStavkes.Count > 1)
                        {
                            var distinctItemId = x.NarudzbaStavkes.Select(y => y.ProizvodId).ToList();

                            distinctItemId.ForEach(y =>
                            {
                                var relatedItems = x.NarudzbaStavkes.Where(z => z.ProizvodId != y);

                                foreach (var z in relatedItems)
                                {
                                    data.Add(new ProductEntry()
                                    {
                                        ProductID = (uint)y,
                                        CoPurchaseProductID = (uint)z.ProizvodId,
                                    });
                                }
                            });
                        }
                    }


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

            var products = _context.Proizvods.Where(x => x.ProizvodId != id);

            var predictionResult = new List<Tuple<Database1.Proizvod, float>>();

            foreach (var product in products)
            {

                var predictionengine = mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                var prediction = predictionengine.Predict(
                                         new ProductEntry()
                                         {
                                             ProductID = (uint)id,
                                             CoPurchaseProductID = (uint)product.ProizvodId
                                         });


                predictionResult.Add(new Tuple<Database1.Proizvod, float>(product, prediction.Score));
            }


            var finalResult = predictionResult.OrderByDescending(x => x.Item2).Select(x => x.Item1).Take(3).ToList();

            return _mapper.Map<List<Model.Proizvod>>(finalResult);

        }

        public override Task<Model.Proizvod> Insert(ProizvodInsertRequest insert)
        {
            var state = _baseState.CreateState("initial");

            return state.Insert(insert);

        }

        public override async Task<Model.Proizvod> Update (int id, ProizvodUpdateRequest update)
        {
            var entity = await _context.Proizvods.FindAsync(id);
            var state = _baseState.CreateState(entity.StateMachine);

            return await state.Update(id, update);
        }

        public async Task<Model.Proizvod> Activate(int id)
        {
            var entity = await _context.Proizvods.FindAsync(id);

            var state = _baseState.CreateState(entity.StateMachine);

            return await state.Activate(id);
        }

        public async Task<Model.Proizvod> Hide(int id)
        {
            var entity = await _context.Proizvods.FindAsync(id);

            var state = _baseState.CreateState(entity.StateMachine);

            return await state.Hide(id);
        }

        public async Task<List<string>> AllowedActions(int id)
        {
            var entity = await _context.Proizvods.FindAsync(id);
            var state = _baseState.CreateState(entity?.StateMachine ?? "initial");
            return await state.AllowedActions();
        }

    }
    //public class Copurchase_prediction
    //{
    //    public float Score { get; set; }
    //}

    //public class ProductEntry
    //{
    //    [KeyType(count: 10)]
    //    public uint ProductID { get; set; }

    //    [KeyType(count: 10)]
    //    public uint CoPurchaseProductID { get; set; }

    //    public float Label { get; set; }
    //}
}
