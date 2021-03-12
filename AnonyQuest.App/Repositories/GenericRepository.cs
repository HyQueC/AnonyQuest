using AnonyQuest.App.Data;
using AnonyQuest.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AnonyQuest.App.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var newEntity = (await _context.AddAsync(entity)).Entity;
            _context.Entry(entity).State = EntityState.Detached;

            return newEntity;
        }

        public virtual T Update(T entity)
        {
            //var ent = _context.Entry(entity);
            //ent.State = EntityState.Modified;
            //return ent.Entity;
            return _context.Update(entity).Entity;
        }

        public virtual async Task<IEnumerable<T>> AllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .AsQueryable()
                .Where(predicate)
                .ToListAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _context.FindAsync<T>(id);
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
