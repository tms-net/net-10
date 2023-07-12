namespace TradingApp
{
    internal class TradingOrder
    {
        internal string OrderId { get; }
        internal string Symbol { get; }
        internal OrderSide OrderSide { get; }
        internal decimal? Price { get; }

        internal decimal Quantity { get; private set; }
        internal OrderStatus Status { get; private set; }

        internal TradingOrder()
        {
        }

        internal void MatchOrder(TradingOrder matchingOrder)
        {
            // TODO: проверить валидность сведения

            // TODO: Изменение параметров ордера

            //Status = OrderStatus.Completed;
        }

        internal bool CancelOrder()
        {
            // TODO: проверить валидность отмены

            Status = OrderStatus.Cancelled;
            return true;
        }
    }
}

