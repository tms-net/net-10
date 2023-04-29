using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlindyukHW5.Vehicle.Entities
{
    abstract class Vehicle : IMovable
    {
        protected Vehicle(int year, string make, string model)
        {
            this.Year = year;
            this.Make = make;
            this.Model = model;
        }

        protected int CurrentSpeed;
        public int Year { get; }
        public string Make { get; }
        public string Model { get; }

        public abstract void Start();
        public virtual void Stop() => CurrentSpeed = 0;

        public override string ToString()
        {
            String a = $"\nYear: {Year}\nMake: {Make}\nModel: {Model}\n";
            return base.ToString() + a;
        }
    }
}
