using Logitravel.Promotions.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logitravel.Promotions.Repository.Interfaces
{
    public interface IReservationRepository
    {
        List<Reservation> GetReservations();

        List<Reservation> GetFilteredReservations(int? hotelCode, int? customerCode);

        Reservation GetReservation(string reservationCode);

        int GetMostBookedHotelCodeByCustomer(int customerCode);
    }
}
