using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBusiness.Entities
{
    public class CustomerOrder : BaseEntity
    {
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public long SubTotal { get; set; }

        public long TotalVAT { get; set; }

        public long Total { get; set; }
    }
}
