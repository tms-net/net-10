using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlindyukHW5.Vehicle.Entities
{
    abstract class Vehicle : IMovable
    {
        protected Vehicle(int Year, string Make, string Model)
        {
            this.Year = Year;
            this.Make = Make;
            this.Model = Model;
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
