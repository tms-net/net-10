using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithOOP
{
    internal class Car : Vehicle
    {
        public Car(int year) : base(year)
        {
        }

        override internal void Start()
        {
            CurrentSpeed = 13;
            throw new NotImplementedException();
        }

        override internal void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
