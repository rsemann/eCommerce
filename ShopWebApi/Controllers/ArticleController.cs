using Shop.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using Shop.Repository.Interfaces;

namespace ShopWebApi.Controllers
{
    [AllowAnonymous]
    public class ArticleController : ApiController
    {
        private IRepository<ArticleDTO> _repository;

        public ArticleController(IRepository<ArticleDTO> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<ArticleDTO> Get()
        {
            //string path = HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data");
            return _repository.GetAll();
        }

        public ArticleDTO Get(int id)
        {
            return _repository.GetById(id);
        }
    }
}
