using System;
using System.Linq;
using Shop.Dto;

namespace ShopBusiness.TemporaryData
{
    public class CartArticleTemporary
    {
        private static CartDTO _cart = new CartDTO();

        public void CleanCart()
        {
            _cart = new CartDTO();
        }

        public StatusCartDTO AddArticle(ArticleDTO article)
        {
            try
            {
                var status = new StatusCartDTO();
                if (_cart.ArticleDtos.Exists(a => a.ArticleId == article.ArticleId))
                {
                    var cartArticle = _cart.ArticleDtos.FirstOrDefault(a => a.ArticleId == article.ArticleId);
                    cartArticle.ArticleQuantity = article.ArticleQuantity;
                    cartArticle.ArticleTotal = article.ArticleQuantity*article.ArticleValue;
                    status.Message = "Article was already on the cart. Quantity updated!";
                    status.TypeMessage = "info";
                }
                else
                {
                    article.ArticleTotal = article.ArticleQuantity * article.ArticleValue;
                    _cart.ArticleDtos.Add(article);
                    status.Message = "Article added to the cart!";
                    status.TypeMessage = "success";
                }

                CalcCart();
                status.TotalArticles = _cart.ArticleDtos.Count;
                return status;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CartDTO GetCart()
        {
            return _cart;
        }

        public void RemoveArticle(int id)
        {
            try
            {
                if (_cart.ArticleDtos.Exists(a => a.ArticleId == id))
                {
                    var cartArticle = _cart.ArticleDtos.FirstOrDefault(a => a.ArticleId == id);
                    _cart.ArticleDtos.Remove(cartArticle);
                    CalcCart();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CalcCart()
        {
            try
            {
                _cart.SubTotal = _cart.ArticleDtos.Sum(a => (a.ArticleValue * a.ArticleQuantity));
                _cart.TotalVAT = (_cart.SubTotal * 19) / 100;
                _cart.Total = _cart.SubTotal + _cart.TotalVAT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
