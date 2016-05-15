using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBusiness.Entities
{
    public class OrderArticle : BaseEntity
    {
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }

        public CustomerOrder Order { get; set; }

        public int ArticleId { get; set; }

        public int Quantity { get; set; }

        public float Total { get; set; }
    }
}
