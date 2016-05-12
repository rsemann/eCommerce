using ShopBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBusiness.DataContext
{
    public class ShopDataContext : DbContext
    {
        public ShopDataContext()
            : base("ShopConnection")
        {
        }

        public IDbSet<Customer> Customer { get; set; }
        public IDbSet<CustomerOrder> CustomerOrder { get; set; }
        public IDbSet<OrderArticle> OrderArticle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
