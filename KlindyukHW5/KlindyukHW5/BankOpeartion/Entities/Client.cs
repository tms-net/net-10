using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlindyukHW5.BankOpeartion.Entities
{
    internal class Client
    {
        internal Client(int ClientId)
        {
            this.ClientId = ClientId;
        }

        public int ClientId { get; }
    }
}
