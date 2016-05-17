using System.Collections.Generic;
using Shop.Models;
using ShopBusiness.Entities;

namespace Shop.Repository.Interfaces
{
    public interface ICustomer
    {
        Customer Get(int id);
        List<Customer> GetMany();
        Customer Put(Customer customer);
        Customer ValidateLogin(CustomerLoginModel loginModel);
    }
}
