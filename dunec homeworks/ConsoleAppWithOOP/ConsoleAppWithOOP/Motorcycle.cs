using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithOOP
{
    internal class Motorcycle : Vehicle, IHaveEngine
    {
        private bool _tripodEjected;

        public Motorcycle(string make, string model, int year) : base(make, model, year)
        {
        }

        public bool succesStart()
        {
            Random ran = new Random();
            if (ran.Next(1, 20) > 5)
            { return true; }
            else
            { return false; }
        }
        public bool succesStop()
        {
            Random ran = new Random();
            if (ran.Next(1, 5) > 2)
            { return true; }
            else
            { return false; }
        }

        override public void Start()
        {
            CurrentSpeed = 21;
            _tripodEjected = false;
        }

        override public void Stop()
        {   
            base.Stop();
            _tripodEjected = true;
        }        
    }
}
