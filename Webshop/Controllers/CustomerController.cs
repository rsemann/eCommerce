using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Shop.Dto;
using Shop.Models;

namespace Webshop.Controllers
{
    [AllowAnonymous]
    public class CustomerController : Controller
    {
        public ActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(CustomerModel model, string returnUrl)
        {
            try
            {
                var customer = new CustomerDTO()
                       {
                           CustomerAddress = model.Address,
                           CustomerCity = model.City,
                           CustomerEmail = model.Email,
                           CustomerFirstName = model.FirstName,
                           CustomerLastName = model.LastName,
                           CustomerPassword = model.Password,
                           CustomerTitle = model.Title,
                           CustomerZipCode = model.ZipCode
                       };
                ViewBag.ReturnUrl = returnUrl;
                await WebApiClient.Obj.Post<CustomerDTO,int>("api/Customer", customer);

                var loginModel = new CustomerLoginModel()
                {
                    Email = model.Email,
                    Password = model.Password
                };

                await this.Login(loginModel, returnUrl);

                return RedirectToLocal(returnUrl);
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(CustomerLoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var loginOk = await ValidateLogin(model);

                if (loginOk)
                {
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError("", "Invalid email or password.");
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        private async Task<bool> ValidateLogin(CustomerLoginModel model)
        {
            var isValid = await WebApiClient.Obj.Authenticate(model.Email, model.Password);

            if (isValid)
            {
                FormsAuthentication.SetAuthCookie(model.Email, false);
                Response.Cookies.Add(new HttpCookie("AuthToken", WebApiClient.Obj.AuthToken));

            }

            return isValid;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            WebApiClient.Obj.AuthToken = string.Empty;
            Response.SetCookie(new HttpCookie("AuthToken", string.Empty));
            Response.Cookies.Remove("AuthToken");


            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}