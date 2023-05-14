using System;
namespace TradingApp
{
    public class BalanceInfo
    {
        public decimal TotalBalance { get; set; }

        // Balance
        // Cash (1000)
        // Shares в валюте (изменяемое)
        public decimal Difference { get; set; }

        public  BalanceInfo(decimal initialValue)
        {
            TotalBalance = initialValue;
        }
    }
}

