using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zanka_dz_5
{
    internal class Motorcycle : Vehicle
    {
        bool _tripodEjected;
        public override void Start()
        {
            _CurrentSpeed = 25;
            throw new NotImplementedException();
        }
        public override void UpdateSpeed()
        {
            _CurrentSpeed = 50;
            throw new NotImplementedException();
        }
        public override void Stop()
        {
            base.Stop();
            _tripodEjected = true;
        }
    }
}
