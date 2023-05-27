using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhdannov_hw9
{
    internal class ATMClient
    {
        private IATMInterface atmInterface;
        private string? cardNumber;

        public ATMClient(IATMInterface atmInterface)
        {
            this.atmInterface = atmInterface;
        }

        public void InsertCard(string? cardNumber, decimal initialBalance)
        {
            this.cardNumber = cardNumber;
            atmInterface.InsertCard(cardNumber, initialBalance);
        }

        public void ViewBalance()
        {
            atmInterface.ViewBalance();
        }

        public void Withdraw(decimal amount)
        {
            atmInterface.Withdraw(amount);
        }

        public void TopUp(decimal amount)
        {
            atmInterface.TopUp(amount);
        }
    }
}
