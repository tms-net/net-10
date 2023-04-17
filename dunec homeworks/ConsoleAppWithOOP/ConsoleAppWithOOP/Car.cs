using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithOOP
{
    internal class Car : Vehicle, IHaveEngine
    {
        public Car(string make, string model, int year) : base(make, model, year)
        {

        }

        public bool succesStart()
        {
            Random ran = new Random();
            if (ran.Next(1, 20) > 10)
            { return true; }
            else 
            { return false; }
        }
        public bool succesStop()
        {
            Random ran = new Random();
            if (ran.Next(1, 5) > 3)
            { return true; }
            else
            { return false; }
        }

        override public void Start()
        {
            CurrentSpeed = 13;
        }
    }
}
