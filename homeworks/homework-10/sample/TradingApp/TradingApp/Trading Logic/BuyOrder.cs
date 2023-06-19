using System;
namespace TradingApp
{
    public class BuyOrder : IOrder
    {
        public DealStatus DealStatus { get; set; }
        public string Symbol { get; init; }
        public int Quantity { get; init; }
        public decimal? Price { get; init; }

        public event Action<DealDetails> OrderFullfilled;

        public BuyOrder(string symbol, int quantity, decimal? price)
        {
            Symbol = symbol;
            Quantity = quantity;
            Price = price;
        }

        public void CancelOrder()
        {
            DealStatus = DealStatus.Cancelled;
        }
    }
}

