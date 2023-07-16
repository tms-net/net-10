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
        OrderInfo _orderInfo;
        // new OrderInfo orderInfo { get; }
        internal decimal Quantity { get; private set; }
        internal OrderStatus Status { get; private set; }

        public TradingOrder(OrderInfo orderInfo, OrderStatus status = OrderStatus.Pending)
        {
          _orderInfo = orderInfo;
          Status = status;
        }

        public void MatchOrder(TradingOrder matchingOrder)
        {
            // TODO (Евгений Липай): проверить валидность сведения
            if (true)
            {

            }
            // TODO (Евгений Липай): Изменение параметров ордера
            if (true)
            {

            }
            Status = OrderStatus.Completed;
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

