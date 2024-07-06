using AutoMapper;
using EasyNetQ;
using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Messages;
using FudbalskiKlub.Model.Requests;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services.ProizvodiStateMachine
{
    public class ActivePlatumState : BaseState
    {
        ILogger<ActivePlatumState> _logger;
        public ActivePlatumState(ILogger<ActivePlatumState>logger, IServiceProvider serviceProvider, Database1.MiniafkContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
            _logger = logger;
        }

        public override async Task<Model.Platum> Hide(int id)
        {
            _logger.LogInformation($"Deaktivacija proizvoda: {id}");

            var set = _context.Set<Database1.Platum>();

            var entity = await set.FindAsync(id);

            entity.StateMachine = "draft";

            await _context.SaveChangesAsync();

            var mappedEntity = _mapper.Map<Model.Platum>(entity);

            try
            {

                var bus = RabbitHutch.CreateBus("host=localhost;username=guest;password=guest");

                PlatumActivated poruka = new PlatumActivated { PlatumPoruka = mappedEntity };

                bus.PubSub.Publish(poruka);

            }
            catch
            {
                _logger.LogError("Nije mogla da se posalje poruka jer RabbitMQ mikroservis ne radi!");
            }


            return _mapper.Map<Model.Platum>(entity);
        }

        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();
            list.Add("Hide");

            return list;
        }
    }
}
