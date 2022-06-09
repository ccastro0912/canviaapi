using Canvia.Domain.Contracts.Interfaces;
using Canvia.Infrastructure.Contracts.UnitOfWork;
using Canvia.Infrastructure.Orm.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Canvia.Domain
{
    public class CustomerBusiness : CommonBusiness, ICustomerBusiness
    {
        public CustomerBusiness(IUnitOfWork unitofwork) : base(unitofwork)
        {

        }
        public async Task<Customer> Create(Customer objeto)
        {
            await _unit.Customer.AddAsync(objeto);
            await _unit.Save();
            return objeto;
        }

        public async Task<Customer> Delete(Customer objeto)
        {
            int result = await _unit.Customer.DeleteAsync(objeto.PKID);
            await _unit.Save();
            return objeto;
        }

        public async Task<Customer> Edit(Customer objeto)
        {
            await _unit.Customer.UpdateAsync(objeto, objeto.PKID);
            await _unit.Save();
            return objeto;
        }

        public async Task<Customer> Get(int Id)
        {
            return await _unit.Customer.FindByIdAsync(Id);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _unit.Customer.GetAllAsync();
        }
    }
}
