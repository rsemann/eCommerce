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
            checkout.SubTotal = checkout.Articles.Sum(a => (a.Value  *a.Quantity));
            checkout.TotalVAT = checkout.Articles.Sum(a => (a.Value * 19)/100);
            checkout.Total = checkout.SubTotal + checkout.TotalVAT;
            return View(checkout);
        }

        // GET: Cart
        public async Task<ActionResult> AddArticle(int id, int quantity)
        {
            var post = await  WebApiClient<ArticleDTO>.Post<StatusCartDTO>("api/articlecart", new ArticleDTO { ArticleId = id, ArticleQuantity = quantity });
            return Json(post, JsonRequestBehavior.AllowGet); ;
        }

        public int TotalArticlesCart()
        {
            var articles = WebApiClient<List<ArticleDTO>>.Get("api/articlecart");
            return articles.Count;
        }
    }
}