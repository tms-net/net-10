using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithOOP.Vehicles
{
    internal class Motorcycle : Vehicle, IHaveEngine
    {
        private bool _tripodEjected = true;

        public Motorcycle(string make, string model, int year, double weigh) : base(make, model, year, weigh)
        {
        }

        public bool SuccesStart()
        {
            Random ran = new Random();
            if (ran.Next(1, 20) > 5)
            { return true; }
            else
            { return false; }
        }
        /*
        public bool SuccesStop()
        {
            Random ran = new Random();
            if (ran.Next(1, 5) > 2)
            { return true; }
            else
            { return false; }
        } //*/

        override public void Start()
        {
            while (!SuccesStart())
            {
                Console.WriteLine("Failed");
            }
            CurrentSpeed = 88;
            _tripodEjected = false;
        }

        override public void Stop()
        {
            base.Stop();
            _tripodEjected = true;
        }
    }
}
