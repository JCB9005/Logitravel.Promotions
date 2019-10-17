using Logitravel.Promotions.Domain;
using Logitravel.Promotions.Entities;
using Logitravel.Promotions.Model;
using Logitravel.Promotions.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using static Logitravel.Promotions.Model.Enums;

namespace Logitravel.Promotions.Tests.DomainTests
{
    public class CustomerDomainTests
    {
        private readonly CustomerDomain _serviceUnderTest;

        private readonly Mock<IZoneRepository> _zoneRepository;
        private readonly Mock<IHotelRepository> _hotelRepository;
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly Mock<IReservationRepository> _reservationRepository;

        public CustomerDomainTests()
        {
            _zoneRepository = new Mock<IZoneRepository>();
            _hotelRepository = new Mock<IHotelRepository>();
            _customerRepository = new Mock<ICustomerRepository>();
            _reservationRepository = new Mock<IReservationRepository>();

            _serviceUnderTest = new CustomerDomain(_zoneRepository.Object, _hotelRepository.Object, _customerRepository.Object, _reservationRepository.Object);
        }

        [Test]
        public void Shuold_return_a_list_of_customers()
        {
            _customerRepository
                .Setup(r => r.GetFilteredCustomers(It.IsAny<bool>()))
                .Returns(GetMockedCustomerList(2));

            var actual = _serviceUnderTest.GetCustomersToNotifyPromotions();

            Assert.True(actual.Any());
        }

        [Test]
        public void Should_return_customer_preferences_when_found()
        {
            _zoneRepository
                .Setup(r => r.GetZone(It.IsAny<int>()))
                .Returns(GetMockedZone());

            _hotelRepository
                .Setup(r => r.GetHotel(It.IsAny<int>()))
                .Returns(GetMockedHotel());

            _reservationRepository
                .Setup(r => r.GetMostBookedHotelCodeByCustomer(It.IsAny<int>()))
                .Returns(23);

            var actual = _serviceUnderTest.GetCustomerPreferences(4789);

            Assert.NotNull(actual);
        }

        [Test]
        public void Should_return_null_when_customer_preferences_not_found()
        {
            _reservationRepository
                .Setup(r => r.GetMostBookedHotelCodeByCustomer(It.IsAny<int>()))
                .Returns(0);

            var actual = _serviceUnderTest.GetCustomerPreferences(4789);

            Assert.Null(actual);
        }

        [Test]
        public void Should_return_a_hotel_list()
        {
            _hotelRepository
                .Setup(r => r.GetFilteredHotels(It.IsAny<int>(), It.IsAny<HotelType>()))
                .Returns(GetMockedHotelList(3));

            var actual = _serviceUnderTest.GetHotelsByCustomerPreferences(new CustomerPreferences { FavouriteZone = GetMockedZone(), FavouriteHotelType = HotelType.Resort });

            Assert.True(actual.Any());
        }

        private Customer GetMockedCustomer()
        {
            return new Customer
            {
                FirstName = "Mockedname",
                Email = "mockedmail@mock.com",
                PromotionsAllowed = false
            };
        }

        private List<Customer> GetMockedCustomerList(int numberOfCustomers)
        {
            List<Customer> customers = new List<Customer>();

            for (int i = 0; i < numberOfCustomers; i++)
            {
                customers.Add(GetMockedCustomer());
            }

            return customers;
        }

        private Zone GetMockedZone()
        {
            return new Zone
            {
                Code = 37,
                Name = "Mocked zone"
            };
        }

        private Hotel GetMockedHotel()
        {
            return new Hotel
            {
                Name = "Mocked hotel"
            };
        }

        private List<Hotel> GetMockedHotelList(int numberOfHotels)
        {
            List<Hotel> hotels = new List<Hotel>();

            for (int i = 0; i < numberOfHotels; i++)
            {
                hotels.Add(GetMockedHotel());
            }

            return hotels;
        }
    }
}
