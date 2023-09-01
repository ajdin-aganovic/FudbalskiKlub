using AutoMapper;
using EasyNetQ;
using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services.ProizvodiStateMachine
{
    public class DraftPlatumState : BaseState
    {
        protected ILogger<DraftPlatumState> _logger;
        public DraftPlatumState(ILogger<DraftPlatumState> logger, IServiceProvider serviceProvider, Database1.MiniafkContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
            _logger = logger;
        }

        public override async Task<Model.Platum> Update(int id, PlatumUpdateRequest request)
        {
            var set = _context.Set<Database1.Platum>();

            var entity = await set.FindAsync(id);

            _mapper.Map(request, entity);

            if (entity.Iznos < 0)
            {
                throw new Exception("Cijena ne moze biti u minusu");
            }


            if (entity.Iznos < 1)
            {
                throw new UserException("Cijena ispod minimuma");
            }


            

            await _context.SaveChangesAsync();
            return _mapper.Map<Model.Platum>(entity);
        }

        public override async Task<Model.Platum> Activate(int id)
        {
            _logger.LogInformation($"Aktivacija proizvoda: {id}");

            _logger.LogWarning($"W: Aktivacija proizvoda: {id}");

            _logger.LogError($"E: Aktivacija proizvoda: {id}");

            var set = _context.Set<Database1.Platum>();

            var entity = await set.FindAsync(id);

            entity.StateMachine = "active";

            await _context.SaveChangesAsync();
            

            //var factory = new ConnectionFactory { HostName = "localhost" };
            //using var connection = factory.CreateConnection();
            //using var channel = connection.CreateModel();


            //string message = "";

            ////JSON$"{entity.ProizvodId}, {entity.Sifra}, {entity.Naziv}";
            //var body = Encoding.UTF8.GetBytes(message);

            //channel.BasicPublish(exchange: string.Empty,
            //                     routingKey: "product_added",
            //                     basicProperties: null,
            //                     body: body);

            var mappedEntity = _mapper.Map<Model.Platum>(entity);

            using var bus = RabbitHutch.CreateBus("host=localhost");

            bus.PubSub.Publish(mappedEntity);

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
