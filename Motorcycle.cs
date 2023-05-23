using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhdanov_hw5
{
    internal class Motorcycle : Vehicle
    {
        public Motorcycle(int year, double engineCapacity, string model, string make) : base(year, engineCapacity, model, make) { }
        private bool _tripodEjected;
        public override void Start()
        {
            _currentSpeed = 20;
            _tripodEjected = false;
        }
        public override void Stop()
        {
            base.Stop();
            _tripodEjected = true;
        }
    }
}
