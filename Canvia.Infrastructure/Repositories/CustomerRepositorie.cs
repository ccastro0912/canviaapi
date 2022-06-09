using Canvia.Infrastructure.Contracts.Repositories;
using Canvia.Infrastructure.Orm.Models;

namespace Canvia.Infrastructure.Repositories
{
    public class CustomerRepositorie : GenericRepositorie<Customer>, ICustomerRepositorie
    {
        public CustomerRepositorie(CanviaContext context): base(context)
        {

        }
    }
}
