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
    public class CheckoutController : ApiController
    {
        private IRepository<CartDTO> _repository;

        public CheckoutController(IRepository<CartDTO> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IHttpActionResult ConfirmCheckout(CartDTO cart)
        {
            _repository.Add(cart);
            return Ok();
        }
    }
}
