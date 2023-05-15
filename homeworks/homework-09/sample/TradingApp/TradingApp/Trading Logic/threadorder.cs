using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingApp.Trading_Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace TradingApp.Trading_Logic
    {
        internal class ThreadOrder
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
                currentPrice = 800/*ссылаемся на цену с биржи */;
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
}
