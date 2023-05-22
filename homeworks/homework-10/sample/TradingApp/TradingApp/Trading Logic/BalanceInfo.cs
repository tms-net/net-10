using System;
namespace TradingApp
{
    // Баланс в валюте
    public class BalanceInfo
    {
        // 1000$
        // BUY MSFT
        // 300$ - 1 MSFT
        //  - 700$ + 1MSFT (Market Price) // - Broker Fee = 1000
        //  MSFT -> 310
        // - 700$ + 1MSFT (Market Price) = 1010
        // Difference = 1010 - 1000 = 10
        // SELL MSFT (310)
        // 1010$


        private readonly decimal _initialBalance;
        private decimal _currentBalance;

        public decimal TotalBalance => _currentBalance;
        public decimal Difference => _currentBalance - _initialBalance;  // изменение, которое внес последний ордер 

        public BalanceInfo(decimal initialValue)
        {
            _initialBalance = initialValue;
            _currentBalance = initialValue;
        }

        public void UpdateBalance(decimal amount, OrderType orderType)
        {
            if (orderType == OrderType.Buy)
            {
                _currentBalance -= amount;
            }
            else if (orderType == OrderType.Sell)
            {
                _currentBalance += amount;
            }
        }
    }
}

