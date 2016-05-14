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
        private static List<ArticleDTO> _cartArticles= new List<ArticleDTO>();

        public void CleanCart()
        {
            _cartArticles = new List<ArticleDTO>();
        }

        public StatusCartDTO AddArticle(ArticleDTO article)
        {
            var status = new StatusCartDTO();
            if (_cartArticles.Exists(a => a.ArticleId == article.ArticleId))
            {
                _cartArticles[article.ArticleId] = article;
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

        public List<ArticleDTO> GetCartArticles()
        {
            return _cartArticles;
        }
    }
}
