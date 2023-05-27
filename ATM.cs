using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhdannov_hw9
{
    internal class ATM: IATMInterface
    {
        private decimal balance;
        public event Action<decimal>? BalanceChanged;

        public void InsertCard(string? cardNumber, decimal initialBalance)
        {
            Console.WriteLine("Card inserted: " + cardNumber);
            balance = initialBalance;
        }

        public void ViewBalance()
        {
            BalanceChanged?.Invoke(balance);
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine("Withdrawn amount: " + amount);
                Console.WriteLine("Remaining balance: " + balance);
            }
            else
            {
                throw new Exception("Insufficient balance.");
            }
        }

        public void TopUp(decimal amount)
        {
            balance += amount;
            Console.WriteLine("Top-up amount: " + amount);
            Console.WriteLine("New balance: " + balance);
        }
    }
}
