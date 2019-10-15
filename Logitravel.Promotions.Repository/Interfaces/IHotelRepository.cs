using Logitravel.Promotions.Model;
using System.Collections.Generic;

namespace Logitravel.Promotions.Repository.Interfaces
{
    interface IHotelRepository
    {
        List<Hotel> GetHotels();

        Hotel GetHotel(int hotelCode);
    }
}
