using Canvia.Infrastructure.Contracts.Repositories;
using Canvia.Infrastructure.Contracts.UnitOfWork;
using Canvia.Infrastructure.Orm.Models;
using Canvia.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace Canvia.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected CanviaContext _context;

        public UnitOfWork(CanviaContext context)
        {
            _context = context;
        }
        public ICustomerRepositorie Customer => new CustomerRepositorie(_context);

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
