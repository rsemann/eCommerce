﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Models;
using Shop.Repository.Interfaces;
using ShopBusiness.DataContext;
using ShopBusiness.Entities;

namespace Shop.Repository.Repositories
{
    public class CustomerAuth : ICustomer
    {
        public Customer Get(int id)
        {
            using (var context = new ShopDataContext())
            {
                return context.Customer.Find(id);
            }
        }

        public List<Customer> GetMany()
        {
            using (var context = new ShopDataContext())
            {
                return context.Customer.ToList();
            }
        }

        public Customer Put(Customer customer)
        {
            using (var context = new ShopDataContext())
            {   
                context.SaveChanges();
                return customer;
            }
        }

        public Customer ValidateLogin(CustomerLoginModel loginModel)
        {
            using (var context = new ShopDataContext())
            {
                return context.Customer.FirstOrDefault(c => c.Email == loginModel.Email && c.Password == loginModel.Password);
            }
        }
    }
}
