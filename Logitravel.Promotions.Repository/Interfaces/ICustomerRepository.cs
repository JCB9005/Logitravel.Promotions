using Logitravel.Promotions.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logitravel.Promotions.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();

        List<Customer> GetFilteredCustomers(bool allowsPromotions);
    }
}
