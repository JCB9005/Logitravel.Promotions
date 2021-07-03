using System;
using System.Collections.Generic;
using System.Configuration;
using static Logitravel.Promotions.Model.Enums;

namespace Logitravel.Promotions.Model.Context
{
    public class LogitravelContext
    {
        private int _zonesCount = int.Parse(ConfigurationManager.AppSettings.Get("NumberOfZones"));
        private int _hotelsCount = int.Parse(ConfigurationManager.AppSettings.Get("NumberOfHotels"));
        private int _customersCount = int.Parse(ConfigurationManager.AppSettings.Get("NumberOfCustomers"));
        private int _reservationsCount = int.Parse(ConfigurationManager.AppSettings.Get("NumberOfReservations"));

        private int _hotelTypes = Enum.GetValues(typeof(HotelType)).Length;

        private static LogitravelContext _instance;

        public static LogitravelContext Instance 
        { 
            get
            {
                if(_instance == null)
                {
                    _instance = new LogitravelContext();
                }

                return _instance;
            }
        }

        private LogitravelContext()
        {
            LoadModel();
        }

        public List<Zone> Zones { get; set; }

        public List<Hotel> Hotels { get; set; }

        public List<Customer> Customers { get; set; }

        public List<Reservation> Reservations { get; set; }

        private void LoadModel()
        {
            LoadZones();
            LoadHotels();
            LoadCustomers();
            LoadReservations();
        }

        private void LoadZones()
        {
            Zones = new List<Zone>();

            for (int i = 1; i <= _zonesCount; i++)
            {
                Zones.Add(new Zone
                {
                    Code = i,
                    Name = $"Zona {i}"
                });
            }
        }

        private void LoadHotels()
        {
            int zoneCount = Zones.Count;

            Hotels = new List<Hotel>();

            for (int i = 1; i <= _hotelsCount; i++)
            {
                Hotels.Add(new Hotel
                {
                    Code = i,
                    Name = $"Hotel {i}",
                    Type = PickRandomHotelType(i%_hotelTypes),
                    ZoneCode = Zones[i % zoneCount].Code
                });
            }
        }

        private HotelType PickRandomHotelType(int coefficient)
        {
            return coefficient switch
            {
                0 => HotelType.Beach,
                1 => HotelType.Urban,
                3 => HotelType.Familiar,
                4 => HotelType.Nature,
                5 => HotelType.Airport,
                _ => HotelType.Resort,
            };
        }

        private void LoadCustomers()
        {
            Customers = new List<Customer>();

            for (int i = 1; i <= _customersCount; i++)
            {
                Customers.Add(new Customer
                {
                    Code = i,
                    FirstName = $"Name {i}",
                    Surname = $"Surname {i}",
                    Email = $"email{i}@logitravel.com",
                    PromotionsAllowed = i % 2 != 0
                });
            }
        }

        private void LoadReservations()
        {
            int hotelsCount = Hotels.Count;
            int customersCount = Customers.Count;

            Reservations = new List<Reservation>();

            for (int i = 0; i < _reservationsCount; i++)
            {
                Reservations.Add(new Reservation
                {
                    Code = Guid.NewGuid().ToString(),
                    HotelCode = Hotels[i % hotelsCount].Code,
                    CustomerCode = Customers[i % customersCount].Code
                });
            }
        }
    }
}
