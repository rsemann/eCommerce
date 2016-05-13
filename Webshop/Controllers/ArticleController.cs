﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Newtonsoft.Json;
using Shop.Dto;
using WebGrease.Css.Extensions;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        [HttpGet]
        public ActionResult Index()
        {
            var articles = new List<ArticleModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApiBaseAddress"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/article").Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    IEnumerable<ArticleDTO> articlesDto = JsonConvert.DeserializeObject<List<ArticleDTO>>(jsonString.Result);
                    articlesDto.ForEach(a => articles.Add(new ArticleModel
                    {
                        Id = a.ArticleId,
                        Description = a.ArticleDescription,
                        Name = a.ArticleName,
                        Value = a.ArticleValue,
                        Quantity = 0
                    }));
                }
            }
            
            ViewBag.PageIndex = 0;
            ViewBag.PageCount = articles.Count / 10;

            return View(articles.Take(10));
        }

        [HttpPost]
        public ActionResult Page(int pageIndex, int pageCount)
        {
            var articles = new List<ArticleModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApiBaseAddress"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/article").Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    IEnumerable<ArticleDTO> articlesDto = JsonConvert.DeserializeObject<List<ArticleDTO>>(jsonString.Result);
                    articlesDto.ForEach(a => articles.Add(new ArticleModel
                    {
                        Id = a.ArticleId,
                        Description = a.ArticleDescription,
                        Name = a.ArticleName,
                        Value = a.ArticleValue,
                        Quantity = 0
                    }));
                }
            }

            ViewBag.PageIndex = pageIndex;
            ViewBag.PageCount = pageCount;

            return View("Index", articles.Skip(pageIndex * 10).Take(10));
        }

        public ActionResult Details(int id)
        {
            var article = new ArticleModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApiBaseAddress"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/article/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    ArticleDTO articleDto = JsonConvert.DeserializeObject<ArticleDTO>(jsonString.Result);
                    article = new ArticleModel
                    {
                        Id = articleDto.ArticleId,
                        Description = articleDto.ArticleDescription,
                        Name = articleDto.ArticleName,
                        Value = articleDto.ArticleValue,
                        Quantity = 0
                    };
                }
            }

            return View(article);
        }
    }
}