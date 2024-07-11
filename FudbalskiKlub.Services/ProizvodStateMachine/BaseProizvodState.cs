﻿using AutoMapper;
using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Services.Database1;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services.ProizvodStateMachine
{
    public class BaseProizvodState
    {
        protected MiniafkContext _context;
        protected IMapper _mapper { get; set; }
        public IServiceProvider _serviceProvider { get; set; }
        public BaseProizvodState(IServiceProvider serviceProvider, MiniafkContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        public virtual Task<Model.Proizvod> Insert(ProizvodInsertRequest request)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.Proizvod> Update(int id, ProizvodUpdateRequest request)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.Proizvod> Activate(int id)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.Proizvod> Hide(int id)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.Proizvod> Delete(int id)
        {
            throw new UserException("Not allowed");
        }

        public BaseProizvodState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                case null:
                    return _serviceProvider.GetService<InitialProizvodState>();
                    break;
                case "draft":
                    return _serviceProvider.GetService<DraftProizvodState>();
                    break;
                case "active":
                    return _serviceProvider.GetService<ActiveProizvodState>();
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