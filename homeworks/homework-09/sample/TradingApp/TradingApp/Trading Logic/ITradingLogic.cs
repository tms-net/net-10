using System;
namespace TradingApp
{
    public interface ITradingLogic
    {
<<<<<<< HEAD
=======
        // Купить по Рыночной цене

        // Продать по Рыночной цене

        // Купить когда цена X

        // Продать когда цена Y (есть на балансе)

>>>>>>> 619e580 (Added  check logic)
        void PlaceOrder(
            string symbol,
            int quantity,
            decimal price,
            OrderPriceType orderPriceType,
            OrderType orderType);

        event Action<BalanceInfo> BalanceChanged;
    }
}

