using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Shop.Dto;
using Shop.Models;
using WebGrease.Css.Extensions;

namespace Webshop.Controllers
{
    public class CartController : Controller
    {
        //[Authorize]
        public ActionResult Index()
        {
            var checkout = new CheckoutModel();
            return View("Checkout", checkout);
        }

        public ActionResult Checkout()
        {
            CartDTO cart = new WebApiClient<CartDTO>().Get("api/articlecart");
            var checkout = new CheckoutModel();
            cart.ArticleDtos.ForEach(a => checkout.Articles.Add(new ArticleModel
            {
                Id = a.ArticleId,
                Name = a.ArticleName,
                Value = a.ArticleValue,
                Quantity = a.ArticleQuantity,
                Total = a.ArticleTotal,
                Image = ConfigurationManager.AppSettings["WebApiBaseAddress"] + a.ArticleImage
            }));
            checkout.SubTotal = cart.SubTotal;
            checkout.TotalVAT = cart.TotalVAT;
            checkout.Total = cart.Total;
            return View("_PartialCheckout", checkout);
        }

        // GET: Cart
        public async Task<ActionResult> AddArticle(int id, int quantity)
        {
            var articleDto = new WebApiClient<ArticleDTO>().Get(string.Format("api/article/{0}", id));
            articleDto.ArticleQuantity = quantity;
            var post = await new WebApiClient<ArticleDTO>().Post<StatusCartDTO>("api/articlecart", articleDto);
            return Json(post, JsonRequestBehavior.AllowGet); ;
        }

        public async Task<ActionResult> RemoveArticle(int id)
        {
            await new WebApiClient<ArticleDTO>().Delete(string.Format("api/articlecart/{0}", id));
            return Checkout();
        }

        public int TotalArticlesCart()
        {
            var cart = new WebApiClient<CartDTO>().Get("api/articlecart");
            return cart.ArticleDtos.Count;
        }

        public async Task<ActionResult> ConfirmCheckout()
        {
            var cart = new WebApiClient<CartDTO>().Get("api/articlecart");
            var orderId = await new WebApiClient<CartDTO>().Post<int>("api/checkout", cart);
            //await WebApiClient<CartDTO>.Get()<int>("api/order", orderId);
            return View();
        }
    }
}