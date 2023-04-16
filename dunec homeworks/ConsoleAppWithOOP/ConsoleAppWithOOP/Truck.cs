using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithOOP
{
    internal class Truck : Vehicle
    {
        public Truck(int year) : base(year)
        {
        }

        override internal void Start()
        {
            CurrentSpeed = 8;
            throw new NotImplementedException();
        }
    }
}
