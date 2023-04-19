using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithOOP.Vehicles
{
    internal class Car : Vehicle, IHaveEngine
    {
        public Car(string make, string model, int year, double weigh) : base(make, model, year, weigh)
        {

        }

        public bool SuccesStart()
        {
            Random ran = new Random();
            if (ran.Next(1, 20) > 10)
            { return true; }
            else
            { return false; }
        }
        /*
        public bool SuccesStop()
        {
            Random ran = new Random();
            if (ran.Next(1, 5) > 3)
            { return true; }
            else
            { return false; }
        }//*/

        override public void Start()
        {
            while (!SuccesStart())
            {
                Console.WriteLine("Failed");
            }
            CurrentSpeed = 69;
        }
    }
}
