using System;
namespace TradingApp
{
    // POCO / Contract / DTO (Data Transfer Object)
    public class OrderInfo
    {
        public string Symbol { get; init; }
        public OrderSide OrderSide { get; init; }
        public decimal Quantity { get; init; }
        public decimal? Price { get; init; }
    }
}

