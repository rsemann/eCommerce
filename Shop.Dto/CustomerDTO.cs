using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Dto
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }

        public string CustomerTitle { get; set; }

        public string CustomerFirstName { get; set; }
        
        public string CustomerLastName { get; set; }

        public string CustomerAddress { get; set; }

        public int CustomerZipCode { get; set; }

        public string CustomerCity { get; set; }

        public string CustomerEmail { get; set; }
    }
}
