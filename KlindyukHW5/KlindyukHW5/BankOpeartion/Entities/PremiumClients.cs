using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlindyukHW5.BankOpeartion.Entities
{
    internal class PremiumClients : Client
    {
        private int Deposit = 1000;
        internal PremiumClients(int ClientId, int Sum) : base(ClientId, Sum)
        {
            this.Sum += Deposit;
        }
    }
}
