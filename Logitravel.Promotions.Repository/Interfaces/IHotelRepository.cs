using Logitravel.Promotions.Model;
using System.Collections.Generic;

namespace Logitravel.Promotions.Repository.Interfaces
{
    public interface IHotelRepository
    {
        List<Hotel> GetHotels();

        Hotel GetHotel(int hotelCode);

        List<Hotel> GetFilteredHotels(int? zoneCode, Enums.HotelType? hotelType);
    }
}
