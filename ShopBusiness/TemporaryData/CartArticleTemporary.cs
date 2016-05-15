using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Dto;

namespace ShopBusiness.TemporaryData
{
    public class CartArticleTemporary
    {
        private static List<ArticleDTO> _cartArticles = new List<ArticleDTO>();

        public void CleanCart()
        {
            _cartArticles = new List<ArticleDTO>();
        }

        public StatusCartDTO AddArticle(ArticleDTO article)
        {
            try
            {
                var status = new StatusCartDTO();
                if (_cartArticles.Exists(a => a.ArticleId == article.ArticleId))
                {
                    var cartArticle = _cartArticles.FirstOrDefault(a => a.ArticleId == article.ArticleId);
                    cartArticle.ArticleQuantity = article.ArticleQuantity;
                    status.Message = "Article was already on the cart. Quantity updated!";
                    status.TypeMessage = "info";
                }
                else
                {
                    _cartArticles.Add(article);
                    status.Message = "Article added to the cart!";
                    status.TypeMessage = "success";
                }

                status.TotalArticles = _cartArticles.Count;
                return status;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ArticleDTO> GetCartArticles()
        {
            return _cartArticles;
        }

        public void RemoveArticle(int id)
        {
            try
            {
                if (_cartArticles.Exists(a => a.ArticleId == id))
                {
                    var cartArticle = _cartArticles.FirstOrDefault(a => a.ArticleId == id);
                    _cartArticles.Remove(cartArticle);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
