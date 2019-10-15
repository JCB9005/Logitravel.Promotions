using Logitravel.Promotions.Model;
using static Logitravel.Promotions.Model.Enums;

namespace Logitravel.Promotions.Entities
{
    public class CustomerPreferences
    {
        public Zone FavouriteZone { get; set; }

        public HotelType FavouriteHotelType { get; set; }
    }
}
