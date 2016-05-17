using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Shop.Dto;
using Shop.Models;
using WebGrease.Css.Extensions;

namespace Webshop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        public ActionResult Index()
        {
            ViewBag.PageIndex = 0;
            ViewBag.PageCount = 1;
            return View(new OrderModel());
        }

        [HttpGet]
        public ActionResult Page(int pageIndex, int pageCount)
        {
            var orders = new List<OrderModel>();
            IEnumerable<CustomerOrderDTO> ordersDto = WebApiClient.Obj.Get<List<CustomerOrderDTO>>("api/order");
            ordersDto.ForEach(o => orders.Add(new OrderModel
            {
                Id = o.CustomerOrderId,
                CustomerId = o.CustomerOrderCustomerId,
                SubTotal = o.CustomerOrderSubTotal,
                TotalVAT = o.CustomerOrderTotalVAT,
                Total = o.CustomerOrderTotal
            }));

            ViewBag.PageIndex = pageIndex;
            ViewBag.PageCount = pageCount;

            return View("_PartialOrders", orders.Skip(pageIndex * 10).Take(10));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }
	}
}