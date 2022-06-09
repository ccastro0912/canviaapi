using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Canvia.Domain.Contracts.Interfaces
{
    public interface IHelperBusiness<T> where T : class
    {
        Task<T> Get(int Id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T objeto);
        Task<T> Edit(T objeto);
        Task<T> Delete(T objeto);
    }
}
