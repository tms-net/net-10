using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zanka_dz_5
{
    internal class Car : Vehicle
    {
        public override void Start()
        {
            _CurrentSpeed = 10;
            throw new NotImplementedException();
        }
        public override void UpdateSpeed()
        {
            _CurrentSpeed = 40;
            throw new NotImplementedException();
        }
    }
}
