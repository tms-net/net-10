using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zanka_dz_5
{
    internal class Truck : Vehicle
    {
        bool trailer;
        public override void Start()
        {
            trailer = true;
            _CurrentSpeed = 5;
            throw new NotImplementedException();
        }
        public override void UpdateSpeed()
        {
            _CurrentSpeed = 20;
            throw new NotImplementedException();
        }
        public override void Stop()
        {
            base.Stop();
            trailer = false;
        }
    }
}
