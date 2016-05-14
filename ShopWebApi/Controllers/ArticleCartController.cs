using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Shop.Dto;
using ShopBusiness.TemporaryData;

namespace ShopWebApi.Controllers
{
    public class ArticleCartController : ApiController
    {
        [HttpPost]
        public IHttpActionResult AddArticleCart(ArticleDTO article)
        {
            var message = new CartArticleTemporary().AddArticle(article);
            return Ok(message);
        }

        [HttpGet]
        public IHttpActionResult GetCartArticles()
        {
            var articles = new CartArticleTemporary().GetCartArticles();
            return Ok(articles);
        }
    }
}
