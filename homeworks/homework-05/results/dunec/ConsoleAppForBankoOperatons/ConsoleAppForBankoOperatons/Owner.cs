using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForBankoOperatons
{
    internal class Owner
    {
        public string? OwnersAdress { get; set; }
        public string? OwnersName { get; set; }

        public Owner(string adress, string name) 
        {
            OwnersAdress = adress;
            OwnersName = name;
        }
    }
}
