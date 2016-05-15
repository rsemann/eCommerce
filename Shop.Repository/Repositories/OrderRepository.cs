using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Dto;
using Shop.Repository.Interfaces;
using ShopBusiness.DataContext;
using ShopBusiness.Entities;

namespace Shop.Repository.Repositories
{
    public class OrderRepository : IRepository<CartDTO>
    {
        public IEnumerable<CartDTO> GetAll()
        {
            try
            {
                var ordersDto = new List<CartDTO>();
                using (var context = new ShopDataContext())
                {
                    var orders = context.CustomerOrder.ToList();
                    orders.ForEach(o => ordersDto.Add(CustomerOrderToDto(o)));
                }

                return ordersDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CartDTO GetById(int id)
        {
            try
            {
                using (var context = new ShopDataContext())
                {
                    var order = context.CustomerOrder.Find(id);
                    return CustomerOrderToDto(order);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Add(CartDTO item)
        {
            try
            {
                using (var context = new ShopDataContext())
                {   
                    var order = new CustomerOrder
                    {
                        CustomerId = 1,
                        SubTotal = item.SubTotal,
                        TotalVAT = item.TotalVAT,
                        Total = item.Total
                    };
                    context.CustomerOrder.Add(order);

                    foreach (var articleDto in item.ArticleDtos)
                    {
                        var article = new OrderArticle()
                        {
                            ArticleId = articleDto.ArticleId,
                            Order = order,
                            Quantity = articleDto.ArticleQuantity,
                            Total = articleDto.ArticleTotal
                        };

                        context.OrderArticle.Add(article);
                    }
                    context.SaveChanges();

                    return order.Id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var context = new ShopDataContext())
                {
                    var order = context.CustomerOrder.Find(id);
                    context.CustomerOrder.Remove(order);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(CartDTO item)
        {
            try
            {
                using (var context = new ShopDataContext())
                {
                    //var order = context.CustomerOrder.Find(item.CustomerOrderId);
                    //order.SubTotal = item.CustomerOrderSubTotal;
                    //order.TotalVAT = item.CustomerOrderTotalVAT;
                    //order.Total = item.CustomerOrderTotal;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private CartDTO CustomerOrderToDto(CustomerOrder order)
        {
            return new CartDTO()
            {
                SubTotal = order.SubTotal,
                TotalVAT = order.TotalVAT,
                Total = order.Total
            };
        }
    }
}
