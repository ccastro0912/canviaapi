using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Canvia.Infrastructure.Contracts.Repositories
{
    public interface IGenericRepositorie<T> where T : class
    {
        Task<int> GetIdentity();
        void SetIdentity(string Tabla, string Modo = "ON");
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> where);
        Task<T> FindSingleByAsync(Expression<Func<T, bool>> where);
        Task<T> FindByIdAsync(int id);
        Task<T> UpdateAsync(T objeto, int id);
        Task<T> AddAsync(T objeto);
        void Delete(T objeto);
        Task<int> DeleteAsync(int id);
        Task<int> CountAsync();

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, T>> select);
        Task<IEnumerable<T>> DistinctAsync(Expression<Func<T, T>> select);
        Task<IEnumerable<T>> DistinctAsync(Expression<Func<T, T>> select, Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);
    }
}
