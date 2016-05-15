using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Dto;
using Shop.Repository.Interfaces;
using ShopBusiness.DataContext;
using ShopBusiness.Entities;

namespace Shop.Repository.Repositories
{
    public class OrderArticleRepository : IRepository<OrderArticleDTO>
    {
        public IEnumerable<OrderArticleDTO> GetAll()
        {
            try
            {
                var articlesOrdersDto = new List<OrderArticleDTO>();
                using (var context = new ShopDataContext())
                {
                    var articles = context.OrderArticle.ToList();
                    articles.ForEach(o => articlesOrdersDto.Add(OrderArticleToDto(o)));
                }

                return articlesOrdersDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public OrderArticleDTO GetById(int id)
        {
            try
            {
                using (var context = new ShopDataContext())
                {
                    var article = context.OrderArticle.Find(id);
                    return OrderArticleToDto(article);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add(OrderArticleDTO item)
        {
            try
            {
                using (var context = new ShopDataContext())
                {
                    var article = new OrderArticle()
                    {
                        ArticleId = item.OrderArticleXmlId,
                        OrderId = item.OrderArticleCustomerOrderId,
                        Quantity = item.OrderArticleQuantity,
                        Total = item.OrderArticleTotal
                    };
                    context.OrderArticle.Add(article);
                    context.SaveChanges();
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
                    var article = context.OrderArticle.Find(id);
                    context.OrderArticle.Remove(article);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(OrderArticleDTO item)
        {
            try
            {
                using (var context = new ShopDataContext())
                {
                    var order = context.OrderArticle.Find(item.OrderArticleId);
                    order.Quantity = item.OrderArticleQuantity;
                    order.Total = item.OrderArticleTotal;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private OrderArticleDTO OrderArticleToDto(OrderArticle article)
        {
            return new OrderArticleDTO()
            {
                OrderArticleId = article.Id,
                OrderArticleXmlId = article.ArticleId,
                OrderArticleCustomerOrderId =  article.OrderId,
                OrderArticleQuantity = article.Quantity,
                OrderArticleTotal = article.Total
            };
        }
    }
}
