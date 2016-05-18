using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using Shop.Dto;
using WebGrease.Css.Extensions;

namespace Webshop.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated && string.IsNullOrEmpty(WebApiClient.Obj.AuthToken))
            {
                FormsAuthentication.SignOut();
                Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddYears(-1);
                Response.Redirect(Request.RawUrl);
                foreach (var cookie in Request.Cookies.AllKeys)
                {
                    Request.Cookies.Remove(cookie);
                }
            }
            return View();
        }
    }
}