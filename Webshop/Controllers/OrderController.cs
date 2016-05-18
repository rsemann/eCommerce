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
            var ordersDto = WebApiClient.Obj.Get<List<CustomerOrderDTO>>("api/order");
            ViewBag.PageIndex = 0;
            ViewBag.PageCount = Math.Ceiling(ordersDto.Count / 10f);
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
            CustomerOrderDTO orderDto = WebApiClient.Obj.Get<CustomerOrderDTO>(string.Format("api/order/{0}",id));
            var orderModel= new OrderModel
            {
                Id = orderDto.CustomerOrderId,
                CustomerId = orderDto.CustomerOrderCustomerId,
                SubTotal = orderDto.CustomerOrderSubTotal,
                TotalVAT = orderDto.CustomerOrderTotalVAT,
                Total = orderDto.CustomerOrderTotal
            };

            
            return View(orderModel);
        }
	}
}