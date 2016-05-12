using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Dto
{
    public class CustomerOrderDTO
    {
        public int CustomerOrderId { get; set; }

        public int CustomerOrderCustomerId { get; set; }

        public float CustomerOrderSubTotal { get; set; }

        public float CustomerOrderTotalVAT { get; set; }

        public float CustomerOrderTotal { get; set; }
    }
}
