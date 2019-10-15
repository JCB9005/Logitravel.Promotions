using Logitravel.Promotions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logitravel.Promotions.Domain.Interfaces
{
    public interface ICustomerDomain
    {
        CustomerPreferences GetCustomerPreferences(int customerCode);
    }
}
