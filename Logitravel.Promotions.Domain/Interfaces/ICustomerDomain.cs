using Logitravel.Promotions.Entities;
using Logitravel.Promotions.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logitravel.Promotions.Domain.Interfaces
{
    public interface ICustomerDomain
    {
        List<Customer> GetCustomersToNotifyPromotions();

        CustomerPreferences GetCustomerPreferences(int customerCode);

        List<Hotel> GetHotelsByCustomerPreferences(CustomerPreferences preferences);
    }
}
