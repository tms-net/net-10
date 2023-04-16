using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithOOP
{
    internal class Motorcycle : Vehicle
    {
        private bool _tripodEjected;

        public Motorcycle(int year) : base(year)
        {
        }

        override internal void Start()
        {
            CurrentSpeed = 21;
            throw new NotImplementedException();
        }

        override internal void Stop()
        {
            base.Stop();
            _tripodEjected = true;
            throw new NotImplementedException();
        }
    }
}
