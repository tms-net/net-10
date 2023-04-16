using KlindyukHW5.BankOpeartion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlindyukHW5.BankOpeartion
{
    internal interface ITransfer
    {
        void Transfer(Client sender, Client recipient, int transferSum);
    }
}
