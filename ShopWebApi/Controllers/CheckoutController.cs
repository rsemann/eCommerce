using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Shop.Dto;
using Shop.Repository.Interfaces;
using ShopBusiness.TemporaryData;

namespace ShopWebApi.Controllers
{
    [AllowAnonymous]
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
            cart.CustomerId = Convert.ToInt32(User.Identity.GetUserId());
            var id = _repository.Add(cart);
            new CartArticleTemporary().CleanCart();
            return Ok(id);
        }
    }
}
