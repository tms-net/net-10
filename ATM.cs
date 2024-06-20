using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhdannov_hw9
{
    internal class ATM
    {
        private decimal balance;
        public ATM(decimal initialBalance)
        {
            balance = initialBalance;
        }

       
        public decimal GetBalance() => balance;
        

        public void Withdraw(decimal amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
            }
            else
            {
                throw new Exception("Insufficient balance.");
            }
        }

        public void TopUp(decimal amount) => balance += amount;
        
    }
}
