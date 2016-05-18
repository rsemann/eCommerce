using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Shop.Dto;
using Shop.Repository.Interfaces;
using ShopBusiness.DataContext;
using ShopBusiness.Entities;

namespace Shop.Repository.Repositories
{
    public class OrderRepository : IRepository<CustomerOrderDTO>
    {
        public IEnumerable<CustomerOrderDTO> GetAll()
        {
            var ordersDto = new List<CustomerOrderDTO>();
            using (var context = new ShopDataContext())
            {
                var orders = context.CustomerOrder.ToList();
                orders.ForEach(o => ordersDto.Add(CustomerOrderToDto(o)));
            }

            return ordersDto;
        }

        public CustomerOrderDTO GetById(int id)
        {
            using (var context = new ShopDataContext())
            {
                return CustomerOrderToDto(context.CustomerOrder.Find(id));
            }
        }

        public int Add(CustomerOrderDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerOrderDTO item)
        {
            throw new NotImplementedException();
        }

        private CustomerOrderDTO CustomerOrderToDto(CustomerOrder order)
        {
            return new CustomerOrderDTO()
            {
                CustomerOrderSubTotal = order.SubTotal,
                CustomerOrderTotalVAT = order.TotalVAT,
                CustomerOrderTotal = order.Total,
                CustomerOrderCustomerId = order.CustomerId,
                CustomerOrderId = order.Id
            };
        }
    }
}
