using System;
namespace TradingApp
{
    // POCO / Contract / DTO (Data Transfer Object)
    public class OrderInfo
    {
        public string Id { get; set; }
        public string Symbol { get; init; }
        public decimal DealPrice => (Quantity * Price) ?? default; // calculated, precalculate
        public OrderType OrderType { get; init; }
        public OrderPriceType OrderPriceType { get; init; }
        public DealStatus Status { get; init; }
        public int Quantity { get; init; }
        public decimal? Price { get; init; }
    }
}

