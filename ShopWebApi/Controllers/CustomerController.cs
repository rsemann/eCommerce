using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Shop.Dto;
using Shop.Repository.Interfaces;

namespace ShopWebApi.Controllers
{
    public class CustomerController : ApiController
    {
        private IRepository<CustomerDTO> _repository;

        public CustomerController(IRepository<CustomerDTO> repository)
        {
            _repository = repository;
        }

        public IHttpActionResult Register(CustomerDTO customer)
        {
            var id = _repository.Add(customer);
            return Ok(id);
        }
    }
}
