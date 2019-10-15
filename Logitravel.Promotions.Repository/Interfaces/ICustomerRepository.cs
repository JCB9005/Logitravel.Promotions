using Logitravel.Promotions.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logitravel.Promotions.Repository.Interfaces
{
    interface ICustomerRepository
    {
        List<Customer> GetCustomers();
    }
}
