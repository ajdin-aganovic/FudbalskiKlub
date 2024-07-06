using AutoMapper;
using EasyNetQ;
using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Messages;
using Microsoft.Extensions.Logging;
using FudbalskiKlub.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services.ProizvodStateMachine
{
    public class ActiveProizvodState : BaseProizvodState
    {
        protected ILogger<ActiveProizvodState> _logger;

        public ActiveProizvodState(ILogger<ActiveProizvodState> logger, IServiceProvider serviceProvider, Database1.MiniafkContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
            _logger = logger;
        }

        public override async Task<Model.Proizvod> Hide(int id)
        {

            _logger.LogInformation($"Deaktivacija proizvoda: {id}");

            //_logger.LogWarning($"W: Deaktivacija proizvoda: {id}");

            //_logger.LogError($"E: Deaktivacija proizvoda: {id}");

            var set = _context.Set<Database1.Proizvod>();

            var entity = await set.FindAsync(id);

            entity.StateMachine = "draft";

            await _context.SaveChangesAsync();


            var mappedEntity = _mapper.Map<Model.Proizvod>(entity);

            try
            {

                var bus = RabbitHutch.CreateBus("host=localhost;username=guest;password=guest");

                ProizvodActivated poruka = new ProizvodActivated { ProizvodPoruka = mappedEntity };

                bus.PubSub.Publish(poruka);

            }
            catch
            {
                _logger.LogError("Nije mogla da se posalje poruka jer RabbitMQ mikroservis ne radi!");
            }


            return _mapper.Map<Model.Proizvod>(entity);
        }

        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();
            list.Add("Hide");

            return list;
        }
    }
}
