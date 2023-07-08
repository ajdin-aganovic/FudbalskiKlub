using AutoMapper;
using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Services.Database1;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services.ProizvodiStateMachine
{
    public class BaseState
    {
        protected MiniafkContext _context;
        protected IMapper _mapper { get; set; }
        public IServiceProvider _serviceProvider { get; set; }
        public BaseState(IServiceProvider serviceProvider, MiniafkContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        public virtual Task<Model.Platum> Insert(PlatumInsertRequest request)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.Platum> Update(int id, PlatumUpdateRequest request)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.Platum> Activate(int id)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.Platum> Hide(int id)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.Platum> Delete(int id)
        {
            throw new UserException("Not allowed");
        }

        public BaseState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                    case null:
                    return _serviceProvider.GetService<InitialPlatumState>();
                    break;
                case "draft":
                    return _serviceProvider.GetService<DraftPlatumState>();
                    break;
                case "active":
                    return _serviceProvider.GetService<ActivePlatumState>();
                    break;

                default:
                    throw new UserException("Not allowed");
            }
        }

        public virtual async Task<List<string>> AllowedActions()
        {
            return new List<string>();
        }

    }
}
