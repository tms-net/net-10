using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_5.Interfaces
{
    internal interface IMovable
    {
        public void StartMovement(int speed);
        public void StopMovement();
        public void UpdateSpeed(int newSpeed);
    }
}
