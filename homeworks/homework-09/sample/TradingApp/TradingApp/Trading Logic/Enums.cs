using System;
namespace TradingApp
{
    public enum DealStatus
    {
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

    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Canceled
    }
}

