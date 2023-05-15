using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TradingApp.Trading_Logic
{
    internal class ThreadOrder
    {
        static bool orderStatus; // отслеживание состояния ордера
        public double requestedPrice { get; set; } // запрашиваемая цена
        public double currentPrice { get; set; } //текущая цена

        static void placeOrder()
        {
            Console.WriteLine("Ордер выставлен");
            orderStatus = true;
        }
        static void cancelOrder()
        {
            Console.WriteLine("Ордер снят");
            orderStatus = false;
        }

        static void Threadbody(ThreadOrder threadOrder)
        {

            Thread threadBody = new Thread(Threadcheck);
            threadBody.Start();
            Thread.Sleep(1000);
            placeOrder();
            Thread.Sleep(1000);
            ////currentPrice = 800/*ссылаемся на цену с биржи */;
            threadOrder.currentPrice;
            Thread.Sleep(1000);
            orderStatus = false;
            threadBody.Join();

        }
        /// <summary>
        /// сравниваем текущую цену с ценой биржи
        /// </summary>
        static void Threadcheck(ThreadOrder threadOrder, OrderType orderType)
        {
            //OrderType MyOrder1 = OrderType.Buy;
            //OrderType MyOrder2 = OrderType.Sell;
            while (orderStatus)
            {
                if (orderType == OrderType.Sell)
                {
                    if (threadOrder.currentPrice <= threadOrder.requestedPrice * 0.8d)
                    {
                        cancelOrder();
                    }
                }
                else
                {
                    if (threadOrder.currentPrice >= threadOrder.requestedPrice * 1.5d)
                    {
                        cancelOrder();
                    }
                }
                return;

            }

        }
        static void Main(string[] args)
        {
            static int CheckOrderPrice(double currentPrice, double dinamicPrice)
            {
                ThreadOrder threadOrder = new ThreadOrder();
                threadOrder.requestedPrice = dinamicPrice;
                threadOrder.currentPrice = currentPrice;
                Threadbody(threadOrder);

            }

        }
    }
}



