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

        [HttpPost]
        public IHttpActionResult GetAllByUser()
        {
            var CustomerId = Convert.ToInt32(User.Identity.GetUserId());
            var id = _repository.GetById(CustomerId);
            return Ok(id);
        }
    }
}
