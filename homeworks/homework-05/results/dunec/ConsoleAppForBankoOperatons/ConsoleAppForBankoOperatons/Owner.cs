using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForBankoOperatons
{
    internal abstract class Owner
    {
        protected string OwnersAdress { get; set; } = string.Empty;
        protected string OwnersName { get; set; } = string.Empty;
    }
}
