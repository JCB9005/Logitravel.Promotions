﻿using System;
using System.Collections.Generic;
using static Logitravel.Promotions.Model.Enums;

namespace Logitravel.Promotions.Model.Context
{
    public class LogitravelContext
    {
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

            for (int i = 1; i <= 5; i++)
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

            for (int i = 1; i <= 10; i++)
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
            switch (coefficient)
            {
                case 0:
                    return HotelType.Beach;
                case 1:
                    return HotelType.Urban;
                case 2:
                default:
                    return HotelType.Resort;
                case 3:
                    return HotelType.Familiar;
                case 4:
                    return HotelType.Nature;
                case 5:
                    return HotelType.Airport;
            }

        }

        private void LoadCustomers()
        {
            Customers = new List<Customer>();

            for (int i = 1; i <= 10; i++)
            {
                Customers.Add(new Customer
                {
                    Code = i,
                    FirstName = $"Name {i}",
                    Surname = $"Surname {i}",
                    Email = $"email{i}@logitravel.com"
                });
            }
        }

        private void LoadReservations()
        {
            int hotelsCount = Hotels.Count;
            int customersCount = Customers.Count;

            Reservations = new List<Reservation>();

            for (int i = 0; i < 100; i++)
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
