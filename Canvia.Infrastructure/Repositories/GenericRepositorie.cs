using Canvia.Infrastructure.Contracts.Repositories;
using Canvia.Infrastructure.Orm.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Canvia.Infrastructure.Repositories
{
    public abstract class GenericRepositorie<T> : IGenericRepositorie<T> where T : class
    {
        protected CanviaContext _context;
        public GenericRepositorie(CanviaContext context) => _context = context;

        public virtual async Task<T> AddAsync(T objeto)
        {
            await _context.AddAsync<T>(objeto);
            return objeto;
        }

        public virtual async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public virtual void Delete(T objeto)
        {
            _context.Remove<T>(objeto);
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            var objeto = await FindByIdAsync(id);
            _context.Set<T>().Remove(objeto);
            return id;
        }

        public virtual async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }

        public virtual async Task<T> FindByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> FindSingleByAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> UpdateAsync(T objeto, int id)
        {
            if (objeto == null) return null;
            T old = await _context.Set<T>().FindAsync(id);
            if (old != null) _context.Entry(old).CurrentValues.SetValues(objeto);
            return old;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, T>> select)
        {
            return await _context.Set<T>().Select(select).ToListAsync();
        }

        public async Task<IEnumerable<T>> DistinctAsync(Expression<Func<T, T>> select)
        {
            return await _context.Set<T>().Select(select)
                                          .Distinct()
                                          .ToListAsync();
        }

        public async Task<IEnumerable<T>> DistinctAsync(Expression<Func<T, T>> select, Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter)
                                          .Select(select)
                                          .Distinct()
                                          .ToListAsync();
        }

        public void SetIdentity(string Tabla, string Modo = "ON")
        {
            _context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {Tabla} {Modo}");
        }

        public virtual Task<int> GetIdentity()
        {
            throw new NotImplementedException();
        }
        public async virtual Task<IEnumerable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> queryable = _context.Set<T>();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
                queryable = queryable.Include<T, object>(includeProperty);

            return await queryable.ToListAsync();
        }
    }
}
