using Logitravel.Promotions.Domain.Interfaces;
using Logitravel.Promotions.Entities;
using Logitravel.Promotions.Model;
using Logitravel.Promotions.Repository;
using Logitravel.Promotions.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logitravel.Promotions.Domain
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IReservationRepository _reservationRepository;

        public CustomerDomain()
        {
            _zoneRepository = new ZoneRepository();
            _hotelRepository = new HotelRepository();
            _customerRepository = new CustomerRepository();
            _reservationRepository = new ReservationRepository();
        }

        public CustomerDomain(IZoneRepository zoneRepository, IHotelRepository hotelRepository, ICustomerRepository customerRepository, IReservationRepository reservationRepository)
        {
            _zoneRepository = zoneRepository;
            _hotelRepository = hotelRepository;
            _customerRepository = customerRepository;
            _reservationRepository = reservationRepository;
        }

        public CustomerPreferences GetCustomerPreferences(int customerCode)
        {
            Hotel hotel = GetMostBookedHotel(customerCode);

            if(hotel != null)
            {
                return new CustomerPreferences
                {
                    FavouriteHotelType = hotel.Type,
                    FavouriteZone = _zoneRepository.GetZone(hotel.ZoneCode)
                };
            }

            return null;
        }

        public List<Hotel> GetHotelsByCustomerPreferences(CustomerPreferences preferences)
        {
            List<Hotel> matchingHotels = _hotelRepository.GetFilteredHotels(preferences.FavouriteZone.Code, preferences.FavouriteHotelType);

            if (!matchingHotels.Any())
            {
                matchingHotels = _hotelRepository.GetFilteredHotels(null, preferences.FavouriteHotelType);
            }

            return matchingHotels;
        }

        public List<Customer> GetCustomersToNotifyPromotions()
        {
            return _customerRepository.GetFilteredCustomers(true);
        }

        private Hotel GetMostBookedHotel(int customerCode)
        {
            int hotelCode = _reservationRepository.GetMostBookedHotelCodeByCustomer(customerCode);

            if(hotelCode > 0)
            {
                return _hotelRepository.GetHotel(hotelCode);
            }

            return null;
        }


    }
}
