using Logitravel.Promotions.Domain.Interfaces;
using Logitravel.Promotions.Entities;
using System;
using System.Collections.Generic;

namespace Logitravel.Promotions.Domain
{
    public class CustomerDomain : ICustomerDomain
    {
        public CustomerPreferences GetCustomerPreferences(int customerCode)
        {
            throw new NotImplementedException();
        }

        public int GetMostBookedHotel(int customerCode)
        {
            /*List<Reservation> customerReservations = LogitravelContext.Instance.Reservations.Where(r => r.CustomerCode == customerCode).ToList();

            var reservationsPerHotel = customerReservations.GroupBy(g => g.HotelCode)
                                        .Select(group => new { HotelCode = group.Key, Count = group.Count() }).OrderBy(g => g.Count);

            reservationsPerHotel.First();*/

            return customerCode;
        }
    }
}
