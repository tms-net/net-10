using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhdanov_hw5
{
    internal abstract class Vehicle : IMove
    {
        protected int _currentSpeed;
        protected Vehicle(int year, double engineCapacity, string model, string make)
        {
            Year = year;
            EngineCapacity = engineCapacity;
            Model = model;
            Make = make;
        }
       
        public int Year { get; } // Год выпуска
       public double EngineCapacity { get; } // Объем двигателя
        public string Model { get; } // Модель
        public string Make { get; }// Производитель
        
      
        public abstract void Start();
        public virtual void Stop()
        {
            _currentSpeed = 0;
        }

        public virtual void VehicleInformation()
        {
            Console.WriteLine($" Vehicle: {Make} {Model}, Engine Capacity: {EngineCapacity}, Year {Year} ");
        }

    }

}
