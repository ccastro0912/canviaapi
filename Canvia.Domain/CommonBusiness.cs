using Canvia.Infrastructure.Contracts.UnitOfWork;

namespace Canvia.Domain
{
    public class CommonBusiness
    {
        protected IUnitOfWork _unit;
        public CommonBusiness(IUnitOfWork unitofwork)
        {
            _unit = unitofwork;
        }
    }
}
