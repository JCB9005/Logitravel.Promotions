using Logitravel.Promotions.Model;
using Logitravel.Promotions.Model.Context;
using Logitravel.Promotions.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logitravel.Promotions.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetCustomers()
        {
            return LogitravelContext.Instance.Customers;
        }
    }
}
