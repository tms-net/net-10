using System;
namespace TradingApp
{
    public class BalanceInfo
    {
        public decimal TotalBalance { get; set; }
        private decimal _balance;
        // Balance
        // Cash (1000)
        // Shares в валюте (изменяемое)
        public decimal Difference { get; set; }


        public void ApdateBalance(decimal amount)
        {
            //депозит и снатяие
            _balance += amount;

            var balanceInfo = new BalanceInfo
            {
                TotalBalance = _balance,
                Difference = amount
            };
            // BalanceChanged?.Invoke(balanceInfo); // уведомление о пополнении баланса
        }
    }
}

