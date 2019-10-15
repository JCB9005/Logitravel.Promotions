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
    }
}
