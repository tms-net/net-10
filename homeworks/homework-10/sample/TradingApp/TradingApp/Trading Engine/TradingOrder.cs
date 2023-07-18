using System.Data;

namespace TradingApp
{
    public class TradingOrder
    {
        //internal static TradingOrder CreateOrderWithStatus(OrderStatus status)
        //{
        //    return new TradingOrder { Status = status };
        //}

        //internal string OrderId { get; }
        //internal string Symbol { get; }
        //internal OrderSide OrderSide { get; }
        //internal decimal? Price { get; }

        //internal decimal Quantity { get; private set; }
        OrderInfo _orderInfo1 { get; }
        OrderInfo _orderInfo2 { get; }
        string _orderID1 { get; }
        string _orderID2 { get; }

        //internal OrderStatus Status { get; private set; }
        public OrderStatus Status { get; set; }

        public TradingOrder(OrderInfo orderInfo1, string orderID1, OrderInfo orderInfo2, string orderID2)
        {
            _orderInfo1 = orderInfo1;
            _orderID1 = orderID1;
       
            _orderInfo2 = orderInfo2;
            _orderID2 = orderID2;

            Status = OrderStatus.Pending;
        }

        public void MatchOrder(TradingOrder matchingOrder)
        {
            
            // TODO (Евгений Липай): проверить валидность сведения
            Status = OrderStatus.Processing;
            var _matchingOrder = matchingOrder;
            if (matchingOrder != null)
            {
                // Проверяем направления
                if ((matchingOrder._orderInfo1.OrderSide == OrderSide.Sell && matchingOrder._orderInfo2.OrderSide == OrderSide.Buy) || 
                    (matchingOrder._orderInfo1.OrderSide == OrderSide.Buy && matchingOrder._orderInfo2.OrderSide == OrderSide.Sell))
                {
                    // Проверяем правильность символов компаний и идентификаторы
                    if ((matchingOrder._orderInfo1.Symbol == "MSFT" || matchingOrder._orderInfo2.Symbol == "AAPL") &&
                        (matchingOrder._orderInfo1.Symbol == "AAPL" || matchingOrder._orderInfo2.Symbol == "MSFT") &&
                        (matchingOrder._orderID1 != matchingOrder._orderID2))
                        
                    {
                        // Проверяем совпадение символов
                        if (matchingOrder._orderInfo1.Symbol == matchingOrder._orderInfo2.Symbol)
                        {
                            // TODO (Евгений Липай): Изменение параметров ордера

                            Status = OrderStatus.PartiallyCompleted;

                            switch (matchingOrder._orderInfo1.OrderSide)
                            {
                                case OrderSide.Sell:
                                    if (matchingOrder._orderInfo1.Price <= matchingOrder._orderInfo2.Price)
                                    {
                                        if ((matchingOrder._orderInfo1.Quantity - matchingOrder._orderInfo2.Quantity) == 0)
                                        {
                                            //Уданяем ордера из таблицы ордеров
                                        }
                                        else if ((matchingOrder._orderInfo1.Quantity - matchingOrder._orderInfo2.Quantity) >1)
                                        {
                                            var balance = matchingOrder._orderInfo1.Quantity - matchingOrder._orderInfo2.Quantity;
                                            // Создаем новый ордер с остатком Sell
                                        }
                                        else
                                        {
                                            var balance = matchingOrder._orderInfo2.Quantity - matchingOrder._orderInfo1.Quantity;
                                            // Создаем новый ордер с остатком Buy
                                        }
                                    }
                                    else
                                    {
                                        throw new ArgumentException();
                                    }
                                    break;
                                case OrderSide.Buy:
                                    if (matchingOrder._orderInfo1.Price >= matchingOrder._orderInfo2.Price)
                                    {
                                        if ((matchingOrder._orderInfo1.Quantity - matchingOrder._orderInfo2.Quantity) == 0)
                                        {
                                            //Уданяем ордера из таблицы ордеров
                                        }
                                        else if ((matchingOrder._orderInfo1.Quantity - matchingOrder._orderInfo2.Quantity) > 1)
                                        {
                                            var balance = matchingOrder._orderInfo1.Quantity - matchingOrder._orderInfo2.Quantity;
                                            // Создаем новый ордер с остатком  Buy
                                        }
                                        else
                                        {
                                            var balance = matchingOrder._orderInfo2.Quantity - matchingOrder._orderInfo1.Quantity;
                                            // Создаем новый ордер с остатком Sell
                                        }
                                    }
                                    else
                                    {
                                        throw new ArgumentException();
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
            

            //Status = OrderStatus.Completed;
        }

        public void CancelOrder()
        {
            // TODO (Анастасия): проверить валидность отмены

            if (Status != OrderStatus.Pending)
            {
                throw new InvalidOperationException();
            }
            
            Status = OrderStatus.Cancelled;
        }
    }
}

