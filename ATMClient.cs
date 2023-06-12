using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhdannov_hw9
{
    internal class ATMClient
    {
       private string? cardNumber;
        private string? balance;
        private ATM atm;

        public ATMClient(ATM atm)
        {
            this.atm = atm;
            this.balance = 0;
            this.atm.BalanceChanged += UpdateBalance;
        }

        public void InsertCard(string? cardNumber, decimal initialBalance)
        {
            this.cardNumber = cardNumber;
            this.balance = initialBalance;
        }

        public void ViewBalance()
        {
            atm.ViewBalance();
        }

        public void Withdraw(decimal amount)
        {
             if (amount <= balance)
            {
                atm.Withdraw(amount);
                balance -= amount;
            }
            else
            {
                throw new Exception("Insufficient balance.");
            }
        }

        public void TopUp(decimal amount)
        {
            atm.TopUp(amount);
            balance += amount;
        }
         private void UpdateBalance()
        {
            balance = atm.GetBalance();
        }
    }
}
