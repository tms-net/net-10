using System;
namespace TradingApp
{
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
}

