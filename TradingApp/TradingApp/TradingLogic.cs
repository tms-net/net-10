using System.Diagnostics;
using System.Threading;

namespace TradingApp
{
    // Торговая логика - Никита Качура
        // Купить/Продать
        // По рыночной цене - 100
        // Ордер
        // Цена достигла значения X 90
    // Отмена ордера при значении Y 80
    // Баланс
    public interface ITradingLogic
    {

        // Купить по Рыночной цене

        // Продать по Рыночной цене

        // Купить когда цена X

        // Продать когда цена Y (есть на балансе)

        OrderInfo PlaceOrder(
            string symbol,
            int quantity,
            decimal price,
            OrderPriceType orderPriceType,
            OrderType orderType);

        event Action<BalanceInfo> BalanceChanged;
    }

    public class BalanceInfo
    {
        public decimal TotalBalance { get; set; }

        // Balance
        // Cash (1000)
        // Shares в валюте (изменяемое)
        public decimal Difference { get; set; }
    }

    public class OrderInfo
    {
        public string Symbol { get; set; }
        public decimal DealPrice { get; set; }
        public DealStatus Status { get; set; }
    }

    public enum DealStatus
    {
        Pending,
        Completed,
        Cancelled
    }

    public enum OrderPriceType
    {
        Market,
        Price
    }

    public enum OrderType
    {
        Buy,
        Sell
    }


    internal class TradingLogic
    {
        static bool orderstatus; // отслеживание состояния ордера
        static double requestedPrice; // запрашиваемая цена
        static double currentPrice; //текущая цена

        static void placeOrder()
        {
            Console.WriteLine("Ордер выставлен по цене: " + requestedPrice);
            orderstatus = true;
        }
        static void cancelOrder()
        {
            Console.WriteLine("Ордер снят: ");
            orderstatus = false;
        }

        static void Threadbody()
        {
            Thread threadOrder = new Thread(Threadcheck);
            threadOrder.Start();
            Thread.Sleep(1000);
            placeOrder();
            Thread.Sleep(1000);
            currentPrice = 80/*ссылаемся на цену с биржи */;
            Thread.Sleep(1000);
            orderstatus = false;
            threadOrder.Join();

        }
        /// <summary>
        /// сравниваем текущую цену с ценой биржи
        /// </summary>
        static void Threadcheck()
        {
            //OrderType MyOrder1 = OrderType.Buy;
            OrderType MyOrder2 = OrderType.Sell;
            while (orderstatus)
            {
                if (MyOrder2 == OrderType.Sell)
                {
                    if (currentPrice <= requestedPrice * 0.8d)
                    {
                        cancelOrder();
                    }
                }
                else
                {
                    if (currentPrice >= requestedPrice * 1.5d)
                    {
                        cancelOrder();
                    }
                }

            }


        }

    }
}
