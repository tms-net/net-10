using System;
namespace TradingApp
{
    public class OrderInfo
    {
        public string Symbol { get; set; }
        public decimal DealPrice { get; set; }
        public DealStatus Status { get; set; }
    }
}

