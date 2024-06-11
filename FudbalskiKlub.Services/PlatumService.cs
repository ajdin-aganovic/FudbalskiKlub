using AutoMapper;
using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Database1;
using FudbalskiKlub.Services.ProizvodiStateMachine;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services
{
    public class PlatumService :
        BaseCRUDService<Model.Platum, Database1.Platum, PlatumSearchObject, PlatumInsertRequest, PlatumUpdateRequest>, IPlatumService
    {
        public BaseState _baseState { get; set; }
        public PlatumService(BaseState baseState, MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
            _baseState = baseState;
        }

        public override IQueryable<Database1.Platum> AddFilter(IQueryable<Database1.Platum> query, PlatumSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.StateMachine))
            {
                filteredQuery = filteredQuery.Where(x => x.StateMachine.Contains(search.StateMachine));
            }

            if (!string.IsNullOrWhiteSpace(search?.MinIznos.ToString()))
            {
                filteredQuery = filteredQuery.Where(x => x.Iznos > search.MinIznos);
            }


            if (!string.IsNullOrWhiteSpace(search?.MaxIznos.ToString()))
            {
                filteredQuery = filteredQuery.Where(x => x.Iznos < search.MaxIznos);
            }

            return filteredQuery;
        }

        public override IQueryable<Database1.Platum> AddInclude(IQueryable<Database1.Platum> query, PlatumSearchObject? search = null)
        {
            if (search?.IsTransakcijskiRacunIncluded == true)
            {
                query = query.Include("TransakcijskiRacun");
            }

            return base.AddInclude(query, search);
        }

        public override async Task<Model.Platum> Update(int id, PlatumUpdateRequest update)
        {
            var entity = await _context.Plata.FindAsync(id);

            var state = _baseState.CreateState(entity.StateMachine);

            return await state.Update(id, update);
        }

        public override Task<Model.Platum> Insert(PlatumInsertRequest insert)
        {
            var state = _baseState.CreateState("initial");

            return state.Insert(insert);

        }

        public async Task<Model.Platum> Activate(int id)
        {
            var entity = await _context.Plata.FindAsync(id);

            var state = _baseState.CreateState(entity.StateMachine);

            return await state.Activate(id);
        }

        public async Task<Model.Platum> Hide(int id)
        {
            var entity = await _context.Plata.FindAsync(id);

            var state = _baseState.CreateState(entity.StateMachine);

            return await state.Hide(id);
        }

        public async Task<List<string>> AllowedActions(int id)
        {
            var entity = await _context.Plata.FindAsync(id);
            var state = _baseState.CreateState(entity?.StateMachine ?? "initial");
            return await state.AllowedActions();
        }
    
    //    static MLContext mlContext = null; 
    //    static object isLocked = new object();
    //    static ITransformer model = null;

    //    public List<Model.Platum> Recommend(int id)
    //    {
    //        lock (isLocked)
    //        {
    //            if (mlContext == null)
    //            {
    //                mlContext = new MLContext();

    //                var tmpData = _context.Narudzbes.Include("NarudzbaStavkes").ToList();
                    
    //                var data = new List<ProductEntry>();


    //                foreach (var x in tmpData)
    //                {
    //                    if(x.NarudzbaStavkes.Count > 1)
    //                    {
    //                        var distinctItemId = x.NarudzbaStavkes.Select(y => y.ProizvodId).ToList();

    //                        distinctItemId.ForEach(y =>
    //                        {
    //                            var relatedItems = x.NarudzbaStavkes.Where(z => z.ProizvodId != y);

    //                            foreach(var z in relatedItems)
    //                            {
    //                                data.Add(new ProductEntry()
    //                                {
    //                                    ProductID = (uint)y,
    //                                    CoPurchaseProductID = (uint)z.ProizvodId,
    //                                });
    //                            }
    //                        });
    //                    }
    //                }


    //                var traindata = mlContext.Data.LoadFromEnumerable(data);

    //                //STEP 3: Your data is already encoded so all you need to do is specify options for MatrxiFactorizationTrainer with a few extra hyperparameters
    //                //        LossFunction, Alpa, Lambda and a few others like K and C as shown below and call the trainer.
    //                MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
    //                options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
    //                options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
    //                options.LabelColumnName = "Label";
    //                options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
    //                options.Alpha = 0.01;
    //                options.Lambda = 0.025;
    //                // For better results use the following parameters
    //                options.NumberOfIterations = 100;
    //                options.C = 0.00001;

    //                var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

    //                model = est.Fit(traindata);

    //            }
    //        }




    //        //prediction

    //        var products = _context.Proizvodis.Where(x => x.ProizvodId != id);

    //        var predictionResult = new List<Tuple<Database1.Proizvodi, float>>();

    //        foreach (var product in products)
    //        {

    //            var predictionengine = mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
    //            var prediction = predictionengine.Predict(
    //                                     new ProductEntry()
    //                                     {
    //                                         ProductID = (uint)id,
    //                                         CoPurchaseProductID = (uint)product.ProizvodId
    //                                     });


    //            predictionResult.Add(new Tuple<Database1.Proizvodi, float>(product, prediction.Score));
    //        }


    //        var finalResult = predictionResult.OrderByDescending(x => x.Item2).Select(x => x.Item1).Take(3).ToList();

    //        return _mapper.Map<List<Model.Proizvodi>>(finalResult);

    //    }

    //}

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
    }
}
