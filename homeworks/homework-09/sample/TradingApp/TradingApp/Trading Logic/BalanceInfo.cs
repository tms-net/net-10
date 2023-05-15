using System;
namespace TradingApp
{
    public class BalanceInfo
    {
        public decimal TotalBalance { get => _balance; private set { _balance = value; } }
        private decimal _balance;
        public decimal Difference { get; private set;} // изменение, которое внес последний ордер 

        public BalanceInfo(decimal initialValue)
        {
            _balance = initialValue;
        }

        public void UpdateBalance(decimal amount, OrderType orderType)
        {
            if (orderType == OrderType.Buy)
            {
                _balance += amount;
                Difference = amount;
            }
            else if (orderType == OrderType.Sell)
            {
                _balance -= amount;
                Difference = amount;
            }

            TotalBalance = _balance;
        }

    }
}

