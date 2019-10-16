using Logitravel.Promotions.Model;
using Logitravel.Promotions.Model.Context;
using Logitravel.Promotions.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logitravel.Promotions.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        public List<Reservation> GetFilteredReservations(int? hotelCode, int? customerCode)
        {
            List<Reservation> reservationList = LogitravelContext.Instance.Reservations;

            if(hotelCode.HasValue)
            {
                reservationList = reservationList.Where(r => r.HotelCode == hotelCode.Value).ToList();
            }

            if (customerCode.HasValue)
            {
                reservationList = reservationList.Where(r => r.CustomerCode == customerCode.Value).ToList();
            }

            return reservationList;
        }

        public Reservation GetReservation(string reservationCode)
        {
            return LogitravelContext.Instance.Reservations.Where(r => r.Code == reservationCode).FirstOrDefault();
        }

        public List<Reservation> GetReservations()
        {
            return LogitravelContext.Instance.Reservations;
        }

        public int GetMostBookedHotelCodeByCustomer(int customerCode)
        {
            return LogitravelContext.Instance.Reservations.Where(r => r.CustomerCode == customerCode).ToList()
                .GroupBy(g => g.HotelCode)
                .Select(group => new { HotelCode = group.Key, Count = group.Count() })
                .OrderBy(g => g.Count)
                .Select(row => row.HotelCode).FirstOrDefault();
        }
    }
}
