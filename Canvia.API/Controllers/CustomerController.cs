using Canvia.Domain.Contracts.Interfaces;
using Canvia.Infrastructure.Orm.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Canvia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly ICustomerBusiness customerBusiness;

        public CustomerController(ICustomerBusiness customerBusiness)
        {
            this.customerBusiness = customerBusiness;
        }

        [HttpGet("[action]")]
        public IActionResult Get(int idCustomer)
        {
            try
            {
                var Result = Success(customerBusiness.Get(idCustomer));
                return Ok(Result);
            }
            catch (Exception ex)
            {
                return Ok(Fail(ex.Message));
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                var Result = Success(customerBusiness.GetAll());
                return Ok(Result);
            }
            catch (Exception ex)
            {
                return Ok(Fail(ex.Message));
            }
        }

        [HttpPost("[action]")]
        public IActionResult Create(Customer customer)
        {
            try
            {
                var Result = customerBusiness.Create(customer);
                return Ok(Success("Cliente creado exitosamente"));
            }
            catch (Exception ex)
            {
                return Ok(Fail(ex.Message));
            }
        }

        [HttpPost("[action]")]
        public IActionResult Edit(Customer customer)
        {
            try
            {
                var Result = customerBusiness.Edit(customer);
                return Ok(Success("Cliente editado exitosamente"));
            }
            catch (Exception ex)
            {
                return Ok(Fail(ex.Message));
            }
        }
    }
}
