namespace TradingApp
{
    // Торговая логика - Никита Качура
        // Купить/Продать
        // По рыночной цене - 100
        // Ордер
        // Цена достигла значения X 90
    // Отмена ордера при значении Y 80
    // Баланс
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

    public class BalanceInfo
    {
        public decimal TotalBalance { get; set; }

        // Balance
        // Cash (1000)
        // Shares в валюте (изменяемое)
        public decimal Difference { get; set; }
    }

    public class OrderInfo
    {
        public string Symbol { get; set; }
        public decimal DealPrice { get; set; }
        public DealStatus Status { get; set; }
    }

    public enum DealStatus
    {
        Pending,
        Completed,
        Cancelled
    }

    public enum OrderPriceType
    {
        Market,
        Price
    }

    public enum OrderType
    {
        Buy,
        Sell
    }

    internal class TradingLogic
    {
    }
}
