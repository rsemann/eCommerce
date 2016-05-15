using System;
using System.Collections.Generic;
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
            IEnumerable<ArticleDTO> articlesDto = WebApiClient<IEnumerable<ArticleDTO>>.Get("api/articlecart");
            var checkout = new CheckoutModel();
            articlesDto.ForEach(a => checkout.Articles.Add(new ArticleModel
            {
                Id = a.ArticleId,
                Name = a.ArticleName,
                Value = a.ArticleValue,
                Quantity = a.ArticleQuantity
            }));
            checkout.SubTotal = checkout.Articles.Sum(a => (a.Value * a.Quantity));
            checkout.TotalVAT = (checkout.SubTotal * 19) / 100;
            checkout.Total = checkout.SubTotal + checkout.TotalVAT;
            return View("_PartialCheckout", checkout);
        }

        // GET: Cart
        public async Task<ActionResult> AddArticle(int id, int quantity)
        {
            var articleDto = WebApiClient<ArticleDTO>.Get(string.Format("api/article/{0}", id));
            articleDto.ArticleQuantity = quantity;
            var post = await WebApiClient<ArticleDTO>.Post<StatusCartDTO>("api/articlecart", articleDto);
            return Json(post, JsonRequestBehavior.AllowGet); ;
        }

        public async Task<ActionResult> RemoveArticle(int id)
        {
            await WebApiClient<ArticleDTO>.Delete(string.Format("api/articlecart/{0}", id));
            return Checkout();
        }

        public int TotalArticlesCart()
        {
            var articles = WebApiClient<List<ArticleDTO>>.Get("api/articlecart");
            return articles.Count;
        }
    }
}