using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBusiness.Entities
{
    public class OrderArticle : BaseEntity
    {
        public int ArticleId { get; set; }

        public int Quantity { get; set; }

        public int Total { get; set; }
    }
}
