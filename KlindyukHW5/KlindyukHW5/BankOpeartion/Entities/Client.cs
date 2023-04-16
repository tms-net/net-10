using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlindyukHW5.BankOpeartion.Entities
{
    internal class Client
    {
        internal Client(int ClientId, int Sum)
        {
            this.ClientId = ClientId;
            this.Sum = Sum;
        }

        internal int ClientId { get; }
        internal int Sum { get; set; }
    }
}
