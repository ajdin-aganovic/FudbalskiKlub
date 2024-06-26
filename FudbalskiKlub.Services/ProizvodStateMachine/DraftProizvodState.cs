using AutoMapper;
using EasyNetQ;
using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Messages;
using FudbalskiKlub.Model.Requests;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services.ProizvodStateMachine
{
    public class DraftProizvodState : BaseProizvodState
    {
        protected ILogger<DraftProizvodState> _logger;
        public DraftProizvodState(ILogger<DraftProizvodState> logger, IServiceProvider serviceProvider, Database1.MiniafkContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
            _logger = logger;
        }

        public override async Task<Model.Proizvod> Update(int id, ProizvodUpdateRequest request)
        {
            var set = _context.Set<Database1.Proizvod>();

            var entity = await set.FindAsync(id);

            _mapper.Map(request, entity);

            if (entity.Kolicina < 0)
            {
                throw new Exception("Kolicina ne moze biti u minusu");
            }


            if (entity.Cijena < 0)
            {
                throw new UserException("Cijena ne smije biti u minisu");
            }

            if (entity.Cijena < 1)
            {
                throw new UserException("Cijena ispod minimuma");
            }




            await _context.SaveChangesAsync();
            return _mapper.Map<Model.Proizvod>(entity);
        }

        public override async Task<Model.Proizvod> Activate(int id)
        {
            _logger.LogInformation($"Aktivacija proizvoda: {id}");

            _logger.LogWarning($"W: Aktivacija proizvoda: {id}");

            _logger.LogError($"E: Aktivacija proizvoda: {id}");

            var set = _context.Set<Database1.Proizvod>();

            var entity = await set.FindAsync(id);

            entity.StateMachine = "active";

            await _context.SaveChangesAsync();



            //var factory = new ConnectionFactory { HostName = "localhost", UserName="guest", Password="Guest" };
            //using var connection = factory.CreateConnection();
            //using var channel = connection.CreateModel();


            //string message = "";

            ////JSON$"{entity.ProizvodId}, {entity.Sifra}, {entity.Naziv}";
            //var body = Encoding.UTF8.GetBytes(message);

            //channel.BasicPublish(exchange: string.Empty,
            //                     routingKey: "product_added",
            //                     basicProperties: null,
            //                     body: body);

            // Naredne zakomentarisane linije moraš otkomentarisati, da bi radio RabbitMQ

            var mappedEntity = _mapper.Map<Model.Proizvod>(entity);

            try
            {

                var bus = RabbitHutch.CreateBus("host=localhost;username=guest;password=guest");

                ProizvodActivated poruka = new ProizvodActivated { ProizvodPoruka = mappedEntity };

                bus.PubSub.Publish(poruka);

            }catch
            {
                _logger.LogError("Nije mogla da se posalje poruka jer RabbitMQ mikroservis ne radi!");
            }

            return mappedEntity;
        }

        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();

            list.Add("Update");
            list.Add("Activate");

            return list;
        }
    }
}
