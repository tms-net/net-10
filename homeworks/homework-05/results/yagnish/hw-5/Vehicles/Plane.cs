using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_5.Vehicles
{
    internal class Plane:Vehicle
    {
        readonly protected int _maxHeight;
        public Plane(string year, string model, string mark, string maxSpeed, int maxHeight) : base(year, model, mark, maxSpeed)
        {
            _maxHeight = maxHeight;
        }
    }
}
