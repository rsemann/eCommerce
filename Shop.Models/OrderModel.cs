using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public float SubTotal { get; set; }

        public float TotalVAT { get; set; }

        public float Total { get; set; }
    }
}
