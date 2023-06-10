using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_5.Vehicles
{
    internal class Car : Vehicle
    {
        readonly protected int _maxPass;
        public Car(string year, string model, string mark, string maxSpeed, int maxPass):base(year, model, mark, maxSpeed)
        {
           _maxPass = maxPass;
        }
    }
}
