using Canvia.Domain;
using Canvia.Domain.Contracts.Interfaces;
using Canvia.Infrastructure.Contracts.UnitOfWork;
using Canvia.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Canvia.API.Ioc
{
    public static class Registros
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddBusiness(services);
            return services;
        }
        private static IServiceCollection AddBusiness(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICustomerBusiness, CustomerBusiness>();
            return services;
        }
    }
}
