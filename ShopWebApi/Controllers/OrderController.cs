using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Shop.Dto;
using Shop.Repository.Interfaces;

namespace ShopWebApi.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        private IRepository<CustomerOrderDTO> _repository;

        public OrderController(IRepository<CustomerOrderDTO> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IHttpActionResult GetAllByUser()
        {
            var result = _repository.GetAll();
            int id = Convert.ToInt32(User.Identity.GetUserId());
            return Ok(result.Where(c => c.CustomerOrderCustomerId == id));
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = _repository.GetById(id);
            return Ok(result);
        }
    }
}
