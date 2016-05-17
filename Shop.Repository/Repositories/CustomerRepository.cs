using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Dto;
using Shop.Repository.Interfaces;
using ShopBusiness.DataContext;
using ShopBusiness.Entities;

namespace Shop.Repository.Repositories
{
    public class CustomerRepository : IRepository<CustomerDTO>
    {
        public IEnumerable<CustomerDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(CustomerDTO item)
        {
            using (var context = new ShopDataContext())
            {
                try
                {
                    var customer = new Customer
                    {
                        Adress = item.CustomerAddress,
                        City = item.CustomerCity,
                        Email = item.CustomerEmail,
                        FirstName = item.CustomerFirstName,
                        LastName = item.CustomerLastName,
                        Title = item.CustomerTitle,
                        ZipCode = item.CustomerZipCode,
                        Password = item.CustomerPassword
                    };
                    context.Customer.Add(customer);

                    context.SaveChanges();
                    

                    return customer.Id;
                }
                catch (Exception ex)
                {
                    
                    throw new Exception(ex.Message);
                }
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
