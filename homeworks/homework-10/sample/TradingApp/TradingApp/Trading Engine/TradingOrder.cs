namespace TradingApp
{
    public class TradingOrder
    {
        internal static TradingOrder CreateOrderWithStatus(OrderStatus status)
        {
            return new TradingOrder { Status = status };
        }

        internal OrderInfo OrderInfo { get; }

        internal decimal Quantity { get; private set; }
        internal OrderStatus Status { get; private set; }

        public TradingOrder()
        {
        }

        public void MatchOrder(TradingOrder matchingOrder)
        {
            // TODO (Евгений Липай): проверить валидность сведения

            // TODO (Евгений Липай): Изменение параметров ордера

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

