using Logitravel.Promotions.Domain;
using Logitravel.Promotions.Domain.Interfaces;
using Logitravel.Promotions.Entities;
using Logitravel.Promotions.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logitravel.Promotions.App
{
    public class PromotionContoller
    {
        private readonly ICustomerDomain _customerDomain;

        public PromotionContoller()
        {
            _customerDomain = new CustomerDomain();
        }

        public PromotionContoller(ICustomerDomain customerDomain)
        {
            _customerDomain = customerDomain;
        }

        public void SendPromotions()
        {
            List<Customer> customers = _customerDomain.GetCustomersToNotifyPromotions();

            Parallel.ForEach(customers, (currentCustomer) =>
            {
                SendPromotion(currentCustomer);
            });
        }

        private void SendPromotion(Customer customer)
        {
            CustomerPreferences preferences = _customerDomain.GetCustomerPreferences(customer.Code);

            List<Hotel> promotionHotels = _customerDomain.GetHotelsByCustomerPreferences(preferences);

            if (promotionHotels.Any())
            {
                SendEmail(customer, preferences, promotionHotels);
            }
        }

        private void SendEmail(Customer customer, CustomerPreferences preferences, List<Hotel> hotels)
        {
            string template = GetEmailTemplate(preferences.FavouriteHotelType);

            StringBuilder body = new StringBuilder($"{customer.FirstName} {customer.Surname} {template}").AppendLine();
            foreach (Hotel hotel in hotels)
            {
                body.AppendLine($"    - {hotel.Name}");
            }

            Console.WriteLine(body.ToString());
        }

        /// <summary>
        /// Debería acceder a un repositorio de plantillas de emails por tipo de hotel
        /// </summary>
        /// <param name="favouriteHotelType"></param>
        /// <returns></returns>
        private string GetEmailTemplate(Enums.HotelType favouriteHotelType)
        {
            string template = $" ha recibido un email promocionando los hoteles de tipo {favouriteHotelType.ToString()}";
            
            return template;
        }
    }
}
