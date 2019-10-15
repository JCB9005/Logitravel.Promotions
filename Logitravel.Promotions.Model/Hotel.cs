using System;
using static Logitravel.Promotions.Model.Enums;

namespace Logitravel.Promotions.Model
{
    public class Hotel
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public int ZoneCode { get; set; }

        public HotelType Type { get; set; }
    }
}
