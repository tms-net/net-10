using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithOOP
{
    internal interface IMovable
    {
        public void Start();
        public void Stop();

        public double GetCurrentSpeed();
    }
}
