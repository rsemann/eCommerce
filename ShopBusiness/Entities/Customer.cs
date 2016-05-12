using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBusiness.Entities
{
    public class Customer : BaseEntity
    {
        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public int ZipCode { get; set; }

        public string City { get; set; }

        public string Email { get; set; }
    }
}
