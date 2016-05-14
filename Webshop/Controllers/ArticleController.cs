﻿using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Shop.Dto;
using Shop.Models;
using WebGrease.Css.Extensions;

namespace Webshop.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<ArticleDTO> articlesDto = WebApiClient<ArticleDTO>.GetAll("api/article");
            
            ViewBag.PageIndex = 0;
            ViewBag.PageCount = articlesDto.Count() / 10;

            return View(new ArticleModel());
        }

        [HttpGet]
        public ActionResult Page(int pageIndex, int pageCount)
        {
            var articles = new List<ArticleModel>();
            IEnumerable<ArticleDTO> articlesDto = WebApiClient<ArticleDTO>.GetAll("api/article");
            articlesDto.ForEach(a => articles.Add(new ArticleModel
            {
                Id = a.ArticleId,
                Name = a.ArticleName,
                Value = a.ArticleValue,
                Quantity = 1
            }));

            ViewBag.PageIndex = pageIndex;
            ViewBag.PageCount = pageCount;

            return View("_PartialArticles", articles.Skip(pageIndex * 10).Take(10));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var articleDto = WebApiClient<ArticleDTO>.Get(string.Format("api/article/{0}", id));
            var article = new ArticleModel
            {
                Id = articleDto.ArticleId,
                Description = articleDto.ArticleDescription,
                Name = articleDto.ArticleName,
                Value = articleDto.ArticleValue,
                Quantity = 1,
                Image = ConfigurationManager.AppSettings["WebApiBaseAddress"] + articleDto.ArticleImage
            };

            return View(article);
        }
    }
}