using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlindyukHW5.BankOpeartion.Entities
{
    internal class PremiumClients : Client
    {
        internal int Deposit { get { return 1000; } }
        internal PremiumClients(int ClientId) : base(ClientId)
        {
        }
    }
}
