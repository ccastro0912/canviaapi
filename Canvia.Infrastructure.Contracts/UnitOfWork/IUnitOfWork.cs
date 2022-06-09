using Canvia.Infrastructure.Contracts.Repositories;
using System.Threading.Tasks;

namespace Canvia.Infrastructure.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepositorie Customer { get; }
        Task<int> Save();
    }
}
