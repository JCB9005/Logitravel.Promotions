using System.Collections.Generic;
using Logitravel.Promotions.Model;
using Logitravel.Promotions.Model.Context;
using System.Linq;
using Logitravel.Promotions.Repository.Interfaces;

namespace Logitravel.Promotions.Repository
{
    public class HotelRepository : IHotelRepository
    {
        public Hotel GetHotel(int hotelCode)
        {
            return LogitravelContext.Instance.Hotels.Where(h => h.Code == hotelCode).FirstOrDefault();
        }

        public List<Hotel> GetHotels()
        {
            return LogitravelContext.Instance.Hotels;
        }

        public int GetMostBookedHotel(int customerCode)
        {
            List<Reservation> customerReservations = LogitravelContext.Instance.Reservations.Where(r => r.CustomerCode == customerCode).ToList();

            var reservationsPerHotel = customerReservations.GroupBy(g => g.HotelCode)
                                        .Select(group => new { HotelCode = group.Key, Count = group.Count() }).OrderBy(g => g.Count);

            reservationsPerHotel.First();

            return customerCode;
        }
    }
}
