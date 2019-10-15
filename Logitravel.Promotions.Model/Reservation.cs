using System;
using System.Collections.Generic;
using System.Text;

namespace Logitravel.Promotions.Model
{
    public class Reservation
    {
        public string Code { get; set; }

        public int HotelCode { get; set; }

        public int CustomerCode { get; set; }
    }
}
