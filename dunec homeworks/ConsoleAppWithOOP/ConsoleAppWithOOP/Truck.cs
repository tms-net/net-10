using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithOOP
{
    internal class Truck : Vehicle, IHaveEngine
    {
        public Truck(string make, string model, int year) : base(make, model, year)
        {
        }

        public bool succesStart()
        {
            Random ran = new Random();
            if (ran.Next(1, 20) > 15)
            { return true; }
            else
            { return false; }
        }
        public bool succesStop()
        {
            Random ran = new Random();
            if (ran.Next(1, 5) > 4)
            { return true; }
            else
            { return false; }
        }

        override public void Start()
        {
            CurrentSpeed = 8;
        }
    }
}
