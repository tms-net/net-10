using System;
namespace TradingApp
{
    public class OrderInfo
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Symbol { get; set; }
        public decimal DealPrice { get; set; }
        public OrderType OrderType { get; set; }
        public DealStatus Status { get; set; }
    }
}

