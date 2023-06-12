using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhdannov_hw9
{
    internal interface IATMInterface
    {
        event Action BalanceChanged;
        void InsertCard(string? cardNumber, decimal initialBalance);
        decimal GetBalance();
        void Withdraw(decimal amount);
        void TopUp(decimal amount);
    }
}
