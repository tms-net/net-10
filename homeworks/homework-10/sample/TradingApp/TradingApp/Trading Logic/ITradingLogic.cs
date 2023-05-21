using System;
namespace TradingApp
{
    public interface ITradingLogic
    {
        void PlaceOrder(
            string symbol,
            int quantity,
            OrderPriceType orderPriceType,
            OrderType orderType,
            decimal? price = null);

        event Action<BalanceInfo> BalanceChanged;
    }
}

