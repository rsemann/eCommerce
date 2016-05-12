using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Dto
{
    public class OrderArticleDTO
    {
        public int OrderArticleId { get; set; }

        public int OrderArticleCustomerOrderId { get; set; }

        public int OrderArticleQuantity { get; set; }

        public float OrderArticleTotal { get; set; }
    }
}
