﻿using AutoMapper;
using FudbalskiKlub.Model;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Database1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services
{
    public class BaseCRUDService<T, TDb, TSearch, TInsert, TUpdate> : BaseService<T, TDb, TSearch> where TDb : class where T : class where TSearch : BaseSearchObject
    {
        public BaseCRUDService(MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual async Task BeforeInsert(TDb entity, TInsert insert)
        {

        }

        public virtual async Task BeforeUpdate(TDb entity, TUpdate update)
        {

        }

        public virtual async Task<T> Insert(TInsert insert)
        {
            var set = _context.Set<TDb>();

            TDb entity = _mapper.Map<TDb>(insert);

            set.Add(entity);
            await BeforeInsert(entity, insert);

            await _context.SaveChangesAsync();
            return _mapper.Map<T>(entity);
        }


        public virtual async Task<T> Update(int id, TUpdate update)
        {
            var set = _context.Set<TDb>();

            var entity = await set.FindAsync(id);

            _mapper.Map(update, entity);
            await BeforeUpdate(entity, update);

            await _context.SaveChangesAsync();
            return _mapper.Map<T>(entity);
        }

        public virtual async Task<T> Delete(int id)
        {
            var set = _context.Set<TDb>();
            

            var itemToDelete = await set.FindAsync(id);

            if (id <= 0)
                throw new NotImplementedException("Not valid ID");
            if (itemToDelete == null)
            {
                throw new NotImplementedException("There is no item under that ID");
            }
            //var entity = await _context.Set<TDb>().FindAsync(id);

            //return _mapper.Map<T>(entity);

            _context.Remove(itemToDelete);
            await _context.SaveChangesAsync();

            return _mapper.Map<T>(itemToDelete); // Successful deletion, return appropriate response



        }

    }
}
