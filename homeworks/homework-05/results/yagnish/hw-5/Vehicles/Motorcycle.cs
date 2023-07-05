using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_5.Vehicles
{
    internal class Motorcycle : Base
    {
        private bool _trypodEjected;
        public Motorcycle(string year, string model, string mark, string maxSpeed) : base(year, model, mark, maxSpeed)
        {
            _trypodEjected = true;
        }
        public void StartMovement(int speed)
        {
            _trypodEjected = false;
            base.StartMovement(speed);
        }
        public void StopMovement()
        {
            _trypodEjected = true;
            base.StopMovement();
        }
    }
}