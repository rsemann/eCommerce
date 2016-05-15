using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Dto
{
    public class ArticleDTO
    {
        public int ArticleId { get; set; }

        public string ArticleName { get; set; }

        public string ArticleDescription { get; set; }

        public float ArticleValue { get; set; }

        public int ArticleQuantity { get; set; }

        public float ArticleTotal { get; set; }

        public string ArticleImage { get; set; }
    }
}
