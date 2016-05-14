using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class CheckoutModel
    {
        public float SubTotal { get; set; }

        public float TotalVAT { get; set; }

        public float Total { get; set; }

        public List<ArticleModel> Articles = new List<ArticleModel>();
    }
}
