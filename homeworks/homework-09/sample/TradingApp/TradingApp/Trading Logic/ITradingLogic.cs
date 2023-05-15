using System;
namespace TradingApp
{
    public interface ITradingLogic
    {
        void PlaceOrder(
            string symbol,
            int quantity,
            decimal price,
            OrderPriceType orderPriceType,
            OrderType orderType);

        event Action<BalanceInfo> BalanceChanged;
    }
}

