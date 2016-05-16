using System.Threading.Tasks;
using System.Web.Mvc;
using Shop.Dto;
using Shop.Models;

namespace Webshop.Controllers
{
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
                await new WebApiClient<CustomerDTO>().Post<int>("api/Customer", customer);

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
            return true;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult LogOff()
        {
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