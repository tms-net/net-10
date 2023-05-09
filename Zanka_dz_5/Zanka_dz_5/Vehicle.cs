using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zanka_dz_5
{
    public interface IVehicle
    {
        void Start();
        void Stop();
    }
    abstract class Vehicle : IVehicle
    {
        protected int _CurrentSpeed;
        public string? Make { get; set; }
        public string? Model { get; set; }
        public  int? Year { get; set; }
        public int MaxSpeed { get; set; }
        public int Maxpeople { get; set; }
        public abstract void Start();
        public virtual void Stop()
        {
            _CurrentSpeed = 0;
        }
        public abstract void UpdateSpeed();

    }
}
