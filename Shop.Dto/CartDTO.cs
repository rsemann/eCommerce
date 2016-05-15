using System.Collections.Generic;

namespace Shop.Dto
{
    public class CartDTO
    {
        public float SubTotal { get; set; }
        public float TotalVAT { get; set; }
        public float Total { get; set; }
        public List<ArticleDTO> ArticleDtos = new List<ArticleDTO>();
    }
}
