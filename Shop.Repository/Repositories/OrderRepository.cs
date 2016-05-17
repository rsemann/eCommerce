using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Dto;
using Shop.Repository.Interfaces;
using ShopBusiness.DataContext;

namespace Shop.Repository.Repositories
{
    public class OrderRepository : IRepository<CustomerOrderDTO>
    {
        public IEnumerable<CustomerOrderDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerOrderDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(CustomerOrderDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerOrderDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
