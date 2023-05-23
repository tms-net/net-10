using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhdanov_hw5
{
    internal class Car : Vehicle
    {
        public Car(int year, double engineCapacity, string model, string make) : base(year, engineCapacity, model, make) { }
        public override void Start()
        {
            _currentSpeed = 10;
        }
    }
}
