using System;

namespace Logitravel.Promotions.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Envío de promociones a clientes");
            Console.WriteLine();

            PromotionContoller promotionContoller = new PromotionContoller();
            promotionContoller.SendPromotions();

            Console.ReadLine();
        }
    }
}
