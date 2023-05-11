using System;
namespace TradingApp
{
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
}

